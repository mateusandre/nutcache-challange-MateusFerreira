#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Nutcache.WebUI/Nutcache.WebUI.csproj", "src/Nutcache.WebUI/"]
RUN dotnet restore "src/Nutcache.WebUI/Nutcache.WebUI.csproj"
COPY . .
WORKDIR "/src/src/Nutcache.WebUI"
RUN dotnet build "Nutcache.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nutcache.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nutcache.WebUI.dll"]