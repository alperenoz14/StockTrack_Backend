#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["StockTrack_Backend_API/StockTrack_Backend_API.csproj", "StockTrack_Backend_API/"]
RUN dotnet restore "StockTrack_Backend_API/StockTrack_Backend_API.csproj"
COPY . .
WORKDIR "/src/StockTrack_Backend_API"
RUN dotnet build "StockTrack_Backend_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StockTrack_Backend_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockTrack_Backend_API.dll"]