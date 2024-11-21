FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["depsmvp-web-api/depsmvp-web-api.csproj", "depsmvp-web-api/"]
COPY ["depsmvp.domain/depsmvp.domain.csproj", "depsmvp.domain/"]
COPY ["depsmvp.application/depsmvp.application.csproj", "depsmvp.application/"]
COPY ["depsmvp.insfrastructure/depsmvp.insfrastructure.csproj", "depsmvp.insfrastructure/"]

RUN dotnet restore "depsmvp-web-api/depsmvp-web-api.csproj"
COPY .. .
WORKDIR "/src/depsmvp-web-api"
RUN dotnet build "depsmvp-web-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "depsmvp-web-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "depsmvp-web-api.dll"]
