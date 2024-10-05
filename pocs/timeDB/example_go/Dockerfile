FROM golang:1.23.2-alpine3.20

WORKDIR /app

COPY . .

RUN go build .

ENTRYPOINT ["go","run","."]