

WORKDIR /app
##############################################
FROM mcr.microsoft.com/dotnet/sdk:5.0.408 AS build
WORKDIR /src

COPY ../VestibularAPI.sln .
COPY ../src/API API/
COPY ../src/Application Application/
COPY ../src/Domain Domain/
COPY ../src/Infrastructure Infrastructure/

RUN dotnet restore "API/API.csproj"

RUN dotnet tool install --global dotnet-ef --version 5.0.17
ENV PATH="$PATH:/root/.dotnet/tools"

WORKDIR "/src/API"

RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --trust
RUN dotnet build "API.csproj" -c Release -o /app/build

##############################################
FROM build AS publish

RUN dotnet publish "API.csproj" -c Release -o /app/publish --no-restore

##############################################
FROM build AS certs

RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https --trust
RUN mkdir -p /root/.aspnet/https
RUN dotnet dev-certs https -ep /root/.aspnet/https/aspnetapp.pfx -p "G3#vB9@xYz!78dK"

##############################################
FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=certs /root/.aspnet/https /root/.aspnet/https

EXPOSE 8098
EXPOSE 8099

ENV ASPNETCORE_URLS="http://+:8098;https://+:8099"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/root/.aspnet/https/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="G3#vB9@xYz!78dK"

ENTRYPOINT ["dotnet", "API.dll"]
