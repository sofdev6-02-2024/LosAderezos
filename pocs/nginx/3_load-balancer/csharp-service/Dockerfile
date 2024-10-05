FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /webapp

COPY ./*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /webapp
COPY --from=build /webapp/out .

EXPOSE 80

ENTRYPOINT ["dotnet","csharpservice.dll"] 