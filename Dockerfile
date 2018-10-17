FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY PumpStation.sln ./
COPY PumpStation.csproj ./
COPY RasberryPiHAL/RasberryPiHAL.csproj RasberryPiHAL/
COPY CommonContracts/CommonContracts.csproj CommonContracts/
COPY DockerCompose/docker-compose.dcproj DockerCompose/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
#WORKDIR /src/PumpStation
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app -r linux-arm

FROM microsoft/dotnet:2.1.5-runtime-stretch-slim-arm32v7 AS runtime
WORKDIR /app
COPY --from=publish /app .
EXPOSE 5000-5001
ENTRYPOINT ["dotnet", "PumpStation.dll", "--urls", "http://0.0.0.0:5000"]
