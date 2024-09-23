FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY *.sln ./
COPY Faena.Api/Faena.Api.csproj Faena.Api/
COPY Faena.Application/Faena.Application.csproj Faena.Application/
COPY Faena.Contracts/Faena.Contracts.csproj Faena.Contracts/
COPY Faena.Domain/Faena.Domain.csproj Faena.Domain/
COPY Faena.Infrastructure/Faena.Infrastructure.csproj Faena.Infrastructure/
RUN dotnet restore "Faena.Api/Faena.Api.csproj"
COPY . ./
RUN dotnet build "Faena.Api/Faena.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish Faena.Api/Faena.Api.csproj -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Faena.Api.dll"]
