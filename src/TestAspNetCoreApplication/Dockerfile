# docker build -t test-aspnetcore-application:latest -f Dockerfile ../..

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

COPY ["src/TestAspNetCoreApplication/TestAspNetCoreApplication.csproj", "/project/src/TestAspNetCoreApplication/"]
COPY ["tests/TestAspNetCoreApplication.IntegrationTests/TestAspNetCoreApplication.IntegrationTests.csproj", "/project/tests/TestAspNetCoreApplication.IntegrationTests/"]
COPY ["TestAspNetCoreApplication.sln", "/project/"]
RUN dotnet restore "/project/TestAspNetCoreApplication.sln"

COPY . "/project/"

RUN dotnet build "/project/TestAspNetCoreApplication.sln" --no-restore -c Release

RUN dotnet test "/project/TestAspNetCoreApplication.sln" --no-build -c Release --logger "trx;LogFileName=TestAspNetCoreApplication.trx" 

FROM build AS publish
RUN dotnet publish "/project/src/TestAspNetCoreApplication/TestAspNetCoreApplication.csproj" --no-build -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish /app

ENTRYPOINT ["dotnet", "TestAspNetCoreApplication.dll"]
