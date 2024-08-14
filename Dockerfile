# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY Teste-Desenvolvedor-.NET.API/*.csproj ./Teste-Desenvolvedor-.NET.API/
COPY Teste-Desenvolvedor-.NET.Data/*.csproj ./Teste-Desenvolvedor-.NET.Data/
COPY Teste-Desenvolvedor-.NET.Domain/*.csproj ./Teste-Desenvolvedor-.NET.Domain/
COPY Teste-Desenvolvedor-.NET.Models/*.csproj ./Teste-Desenvolvedor-.NET.Models/
COPY Teste-Desenvolvedor-.NET.Services/*.csproj ./Teste-Desenvolvedor-.NET.Services/
COPY Teste-Desenvolvedor-.NET.Shared/*.csproj ./Teste-Desenvolvedor-.NET.Shared/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expose the port the application runs on
EXPOSE 80
EXPOSE 443
EXPOSE 8080

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Teste-Desenvolvedor-.NET.API.dll"]
