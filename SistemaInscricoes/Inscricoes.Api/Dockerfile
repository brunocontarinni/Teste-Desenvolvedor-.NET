#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Inscricoes.Api/Inscricoes.Api.csproj", "Inscricoes.Api/"]
COPY ["Inscricoes.CrossCutting/Inscricoes.CrossCutting.csproj", "Inscricoes.CrossCutting/"]
COPY ["Inscricoes.Application/Inscricoes.Application.csproj", "Inscricoes.Application/"]
COPY ["Inscricoes.Domain/Inscricoes.Domain.csproj", "Inscricoes.Domain/"]
COPY ["Inscricoes.Shared/Inscricoes.Shared.csproj", "Inscricoes.Shared/"]
COPY ["Inscricoes.Infrastructure/Inscricoes.Infrastructure.csproj", "Inscricoes.Infrastructure/"]
RUN dotnet restore "./Inscricoes.Api/Inscricoes.Api.csproj"
COPY . .
WORKDIR "/src/Inscricoes.Api"
RUN dotnet build "./Inscricoes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Inscricoes.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inscricoes.Api.dll"]