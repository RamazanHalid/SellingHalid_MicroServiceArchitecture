#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5004
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/CatelogService/CatelogService.Api/CatalogService.Api.csproj", "src/Services/CatelogService/CatelogService.Api/"]
RUN dotnet restore "src/Services/CatelogService/CatelogService.Api/CatalogService.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/CatelogService/CatelogService.Api"
RUN dotnet build "CatalogService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogService.Api.dll"]