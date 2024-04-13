FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5120

ENV ASPNETCORE_URLS=http://+:5120

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["SistemaReceitas.API/SistemaReceitas.API.csproj", "SistemaReceitas.API/"]
RUN dotnet restore "SistemaReceitas.API/SistemaReceitas.API.csproj"
COPY . .
WORKDIR "/src/SistemaReceitas.API"
RUN dotnet build "SistemaReceitas.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "SistemaReceitas.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaReceitas.API.dll"]
