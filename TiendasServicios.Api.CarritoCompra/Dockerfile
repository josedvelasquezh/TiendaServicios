#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["TiendasServicios.Api.CarritoCompra/TiendasServicios.Api.CarritoCompra.csproj", "TiendasServicios.Api.CarritoCompra/"]
RUN dotnet restore "TiendasServicios.Api.CarritoCompra/TiendasServicios.Api.CarritoCompra.csproj"
COPY . .
WORKDIR "/src/TiendasServicios.Api.CarritoCompra"
RUN dotnet build "TiendasServicios.Api.CarritoCompra.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TiendasServicios.Api.CarritoCompra.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TiendasServicios.Api.CarritoCompra.dll"]
