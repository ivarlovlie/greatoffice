FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY src/*.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY src/ ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /source/out .
ENTRYPOINT ["dotnet", "IOL.GreatOffice.Api.dll"]
