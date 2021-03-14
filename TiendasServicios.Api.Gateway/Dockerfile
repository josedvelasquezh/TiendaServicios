#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TiendasServicios.Api.Gateway/TiendasServicios.Api.Gateway.csproj", "TiendasServicios.Api.Gateway/"]
RUN dotnet restore "TiendasServicios.Api.Gateway/TiendasServicios.Api.Gateway.csproj"
COPY . .
WORKDIR "/src/TiendasServicios.Api.Gateway"
RUN dotnet build "TiendasServicios.Api.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TiendasServicios.Api.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendasServicios.Api.Gateway.dll"]
