FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Proyecto-BeerStore/Proyecto-BeerStore.csproj", "Proyecto-BeerStore/"]
RUN dotnet restore "Proyecto-BeerStore/Proyecto-BeerStore.csproj"
COPY . .
WORKDIR "/src/Proyecto-BeerStore"
RUN dotnet build "Proyecto-BeerStore.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Proyecto-BeerStore.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Proyecto-BeerStore.dll"]
