# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiando o arquivo .csproj para restaurar as dependências
COPY ["VestibularApi/VestibularApi/VestibularApi.csproj", "VestibularApi/"]
RUN dotnet restore "VestibularApi/VestibularApi.csproj"

# Copiando todo o restante do código
COPY . .

# Definindo o diretório de trabalho e compilando a aplicação
WORKDIR "/src/VestibularApi"
RUN dotnet build "VestibularApi.csproj" -c Release

# Stage 2: Publish
FROM build AS publish
WORKDIR /src/VestibularApi
RUN dotnet publish "VestibularApi.csproj" -c Release -o /app/publish

# Stage 3: Final Image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Expondo a porta 80 para tráfego HTTP
EXPOSE 80

# Copiando a aplicação publicada para a imagem final
COPY --from=publish /app/publish .

# Comando de entrada para executar a aplicação
ENTRYPOINT ["dotnet", "VestibularApi.dll"]
