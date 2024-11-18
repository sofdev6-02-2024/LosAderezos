package main

import (
	"fmt"
	"encoding/json"
	"log"
	"net/http"
	"html/template"
	"io/ioutil"
	"os"
	"sort"
	"bytes"

	"github.com/subosito/gotenv"
	"github.com/gorilla/sessions"
	"github.com/gorilla/pat"
	"github.com/markbates/goth"
	"github.com/markbates/goth/gothic"

	"github.com/markbates/goth/providers/google"
)

const(
	key = "randomString"
	MaxAge = 86400 * 30
	IsProd = false
)

func main() {
	gotenv.Load()

	redirectionFrontEndRootUrl := os.Getenv("REDIRECTION_LOGIN_FAILED")
	redirectionBackendPostSessionUrl := os.Getenv("POST_TOKEN_SESSION")
	redirectionBackendGetCookieUrl := os.Getenv("REDIRECTION_TO_GET_COOKIE_URL")

	store := sessions.NewCookieStore([]byte(key))
	store.Options.Path = "/"
	store.Options.HttpOnly = true

	gothic.Store = store

	goth.UseProviders(
		google.New(os.Getenv("GOOGLE_KEY"), os.Getenv("GOOGLE_SECRET"), os.Getenv("GOOGLE_CALLBACK_URL")),
	)


	m := map[string]string{
		"google":          "Google",
		}

	var keys []string
	for k := range m {
		keys = append(keys, k)
	}
	sort.Strings(keys)

	providerIndex := &ProviderIndex{Providers: keys, ProvidersMap: m}

	p := pat.New()
	p.Get("/{provider}/callback", func(res http.ResponseWriter, req *http.Request) {
		fmt.Println("ENTERING")

		user, err := gothic.CompleteUserAuth(res, req)
		if err != nil {
			res.Header().Set("Location", redirectionFrontEndRootUrl)
			res.WriteHeader(http.StatusTemporaryRedirect)
		}

		fmt.Println("FIRST")

		userEmail := user.Email
		userToken := user.AccessToken
	
		var jsonStr = []byte("{\"email\" : \""+userEmail+"\",\"token\"	: \""+userToken+"\"}")
		jreq, jerr := http.NewRequest("POST",redirectionBackendPostSessionUrl, bytes.NewBuffer(jsonStr))
		jreq.Header.Set("Content-Type","application/json")

		client := &http.Client{}
		hresp, jerr := client.Do(jreq)
		if jerr != nil {
			return
		}

		fmt.Println("SECOND")

		defer hresp.Body.Close()

		var r PostCookieRequest

		requestBody, err := ioutil.ReadAll(hresp.Body)

		fmt.Println(requestBody)

		err = json.Unmarshal(requestBody, &r)
		if err != nil {
			fmt.Println(err)
			return
		}

		fmt.Println("THIRD")
		
		res.Header().Set("Location", redirectionBackendGetCookieUrl+r.UserID)
		res.WriteHeader(http.StatusTemporaryRedirect)
	})

	p.Get("/logout/{provider}", func(res http.ResponseWriter, req *http.Request) {
		gothic.Logout(res, req)
		res.Header().Set("Location", "http://localhost:8000")
		res.WriteHeader(http.StatusTemporaryRedirect)
	})

	p.Get("/{provider}", func(res http.ResponseWriter, req *http.Request) {
		fmt.Println("LOGIN")
		gothic.BeginAuthHandler(res, req)
	})

	p.Get("/", func(res http.ResponseWriter, req *http.Request) {
		t, _ := template.New("foo").Parse(indexTemplate)
		t.Execute(res, providerIndex)
	})

	log.Println("listening on localhost:8000")
	log.Fatal(http.ListenAndServe(":8000", p))
}

var indexTemplate = `{{range $key,$value:=.Providers}}
    <p><a href="/{{$value}}">Log in with {{index $.ProvidersMap $value}}</a></p>
{{end}}`

type PostCookieRequest struct {
	UserID      string `json:"userId"`
	Name        string `json:"name"`
	Rol         string `json:"rol"`
	Email       string `json:"email"`
	PhoneNumber string `json:"phoneNumber"`
	BirthDate   string `json:"birthDate"`
	Token       string `json:"token"`
	Time        string `json:"time"`
}

type ProviderIndex struct {
	Providers    []string
	ProvidersMap map[string]string
}
