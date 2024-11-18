FROM golang:1.23

WORKDIR /app

COPY ./apps/ThirdAutentication/ .
COPY ./infrastructure/environments/third-authentication/ .
RUN go build

ENTRYPOINT ["go","run","."]
