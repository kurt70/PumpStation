FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ../PumpStation.sln ./
COPY PumpStation/PumpStation.csproj PumpStation/
COPY RasberryPiHAL/RasberryPiHAL.csproj RasberryPiHAL/
COPY CommonContracts/CommonContracts.csproj CommonContracts/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/PumpStation
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app -r linux-arm

FROM microsoft/dotnet:2.0.0-runtime-stretch-arm32v7

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PumpStation.dll"]
