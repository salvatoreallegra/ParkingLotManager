# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ["AnalyticsService.Api/AnalyticsService.Api.csproj", "AnalyticsService.Api/"]
RUN dotnet restore "AnalyticsService.Api/AnalyticsService.Api.csproj"

# Copy everything and build
COPY . .
WORKDIR /src/AnalyticsService.Api
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "AnalyticsService.Api.dll"]
