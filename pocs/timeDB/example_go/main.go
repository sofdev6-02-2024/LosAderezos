package main

import (
  "os"
  "time"
  "context"
  "log"
  "fmt"

  influxdb2 "github.com/influxdata/influxdb-client-go/v2"
  "github.com/influxdata/influxdb-client-go/v2/api/write"

  "github.com/joho/godotenv"
)

func main() {
	err := godotenv.Load(".env")

  	if err != nil {
    	log.Fatalf("Error loading .env file")
  	}
	
  	token := os.Getenv("INFLUXDB_TOKEN")
  	url := "http://influxdb:8086"
  	client := influxdb2.NewClient(url, token)
  	org := "org"

	// WRITE DATA
	bucket := "BUCKET_EXAMPLE"
	writeAPI := client.WriteAPIBlocking(org, bucket)
	for value := 0; value < 2; value++ {
		tags := map[string]string{
			"switch_state": "on",
		}
		fields := map[string]interface{}{
			"number": value,
		}
		point := write.NewPoint("measurement1", tags, fields, time.Now())
		time.Sleep(1 * time.Second) // separate points by 1 second

		if err := writeAPI.WritePoint(context.Background(), point); err != nil {
			log.Fatal(err)
		}
	}
	
	fmt.Println("SIMPLE QUERY EXAMPLE")	
	fmt.Println("------------------------------------------------------------")

	// SIMPLE QUERY
	queryAPI := client.QueryAPI(org)
	query := `from(bucket: "BUCKET_EXAMPLE")
            	|> range(start: -7s)
            	|> filter(fn: (r) => r._measurement == "measurement1")`
	results, err := queryAPI.Query(context.Background(), query)
	if err != nil {
	    log.Fatal(err)
	}
	for results.Next() {
	    fmt.Println(results.Record())
	}
	if err := results.Err(); err != nil {
	    log.Fatal(err)
	}

	fmt.Println("AGGREGATE QUERY EXAMPLE")	
	fmt.Println("------------------------------------------------------------")

	//AGGREGATE QUERY
	query = `from(bucket: "BUCKET_EXAMPLE")
              |> range(start: -10m)
              |> filter(fn: (r) => r._measurement == "measurement1")
              |> mean()`
	results, err = queryAPI.Query(context.Background(), query)
	if err != nil {
	    log.Fatal(err)
	}
	for results.Next() {
	    fmt.Println(results.Record())
	}
	if err := results.Err(); err != nil {
	    log.Fatal(err)
	}
}
