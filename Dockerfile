FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["VestibularApi/VestibularApi/VestibularApi.csproj", "VestibularApi/"]
RUN dotnet restore "VestibularApi/VestibularApi.csproj"

COPY . .
WORKDIR "/src/VestibularApi"
RUN dotnet build "VestibularApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VestibularApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VestibularApi.dll"]
