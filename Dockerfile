# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY SMPPI.Dashboard/SMPPI.Dashboard.csproj SMPPI.Dashboard/
RUN dotnet restore "SMPPI.Dashboard/SMPPI.Dashboard.csproj"

# Copy everything else and build
COPY SMPPI.Dashboard/ SMPPI.Dashboard/
WORKDIR /src/SMPPI.Dashboard
RUN dotnet build "SMPPI.Dashboard.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "SMPPI.Dashboard.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080

# Copy published files
COPY --from=publish /app/publish .

# Set environment variables for Railway
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Run the application
ENTRYPOINT ["dotnet", "SMPPI.Dashboard.dll"]
