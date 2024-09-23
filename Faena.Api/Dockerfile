#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Faena.Api/Faena.Api.csproj", "Faena.Api/"]
COPY ["Faena.Application/Faena.Application.csproj", "Faena.Application/"]
COPY ["Faena.Domain/Faena.Domain.csproj", "Faena.Domain/"]
COPY ["Faena.Contracts/Faena.Contracts.csproj", "Faena.Contracts/"]
COPY ["Faena.Infrastructure/Faena.Infrastructure.csproj", "Faena.Infrastructure/"]
RUN dotnet restore "./Faena.Api/Faena.Api.csproj"
COPY . .
WORKDIR "/src/Faena.Api"
RUN dotnet build "./Faena.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Faena.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Faena.Api.dll"]