# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:5.0.103 AS build-env
WORKDIR /App

# Publish the web application
COPY p2ska/ App/
RUN dotnet publish -o out App/p2ska.csproj

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT dotnet p2ska.dll