FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Apps/DND5EHandler/src/Api/Api.csproj", "Apps/DND5EHandler/src/Api/"]
COPY ["Apps/DND5EHandler/src/Infrastructure/Infrastructure.csproj", "Apps/DND5EHandler/src/Infrastructure/"]
COPY ["Apps/DND5EHandler/src/Core/Core.csproj", "Apps/DND5EHandler/src/Core/"]

RUN dotnet restore "Apps/DND5EHandler/src/Api/Api.csproj"

COPY Apps/DND5EHandler/src/Api/ Apps/DND5EHandler/src/Api/
COPY Apps/DND5EHandler/src/Infrastructure/ Apps/DND5EHandler/src/Infrastructure/
COPY Apps/DND5EHandler/src/Core/ Apps/DND5EHandler/src/Core/

WORKDIR "Apps/DND5EHandler/src/Api"
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
