FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /App
RUN dotnet new tool-manifest
RUN dotnet tool install  dotnet-ef
# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet dev-certs https --trust
EXPOSE 7170
ENTRYPOINT dotnet run  --urls=https://+:7170 --project RestService.csproj