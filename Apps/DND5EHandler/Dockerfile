FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Apps/DND5EHandler/api/api.csproj", "Apps/DND5EHandler/api/"]
COPY ["Apps/DND5EHandler/service/service.csproj", "Apps/DND5EHandler/service/"]
COPY ["Apps/DND5EHandler/infrastructure/infrastructure.csproj", "Apps/DND5EHandler/infrastructure/"]
COPY ["Apps/DND5EHandler/Domain/Domain.csproj", "Apps/DND5EHandler/Domain/"]

RUN dotnet restore "Apps/DND5EHandler/api/api.csproj"

COPY Apps/DND5EHandler/api/ Apps/DND5EHandler/api/
COPY Apps/DND5EHandler/service/ Apps/DND5EHandler/service/
COPY Apps/DND5EHandler/infrastructure/ Apps/DND5EHandler/infrastructure/
COPY Apps/DND5EHandler/Domain/ Apps/DND5EHandler/Domain/

WORKDIR "Apps/DND5EHandler/api"
RUN dotnet build "./api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]
