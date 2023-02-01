#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Nutcache.WebApi/Nutcache.WebApi.csproj", "src/Nutcache.WebApi/"]
COPY ["src/Nutcache.Infra.Data/Nutcache.Infra.Data.csproj", "src/Nutcache.Infra.Data/"]
COPY ["src/Nutcache.Domain/Nutcache.Domain.csproj", "src/Nutcache.Domain/"]
COPY ["src/Nutcache.Infra.IoC/Nutcache.Infra.IoC.csproj", "src/Nutcache.Infra.IoC/"]
COPY ["src/Nutcache.Application/Nutcache.Application.csproj", "src/Nutcache.Application/"]
RUN dotnet restore "src/Nutcache.WebApi/Nutcache.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Nutcache.WebApi"
RUN dotnet build "Nutcache.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nutcache.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nutcache.WebApi.dll"]