# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore
COPY ["SensorService.Api/SensorService.Api.csproj", "SensorService.Api/"]
COPY ["SensorService.Application/SensorService.Application.csproj", "SensorService.Application/"]
COPY ["SensorService.Domain/SensorService.Domain.csproj", "SensorService.Domain/"]
COPY ["SensorService.Infrastructure/SensorService.Infrastructure.csproj", "SensorService.Infrastructure/"]
RUN dotnet restore "SensorService.Api/SensorService.Api.csproj"

# Copy everything and build
COPY . .
WORKDIR /src/SensorService.Api
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SensorService.Api.dll"]
