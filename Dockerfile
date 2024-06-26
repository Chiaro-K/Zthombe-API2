FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Zthombe-API/Zthombe-API.csproj", "Zthombe-API/"]
COPY ["Zthombe.Data/Zthombe.Data.csproj", "Zthombe.Data/"]
RUN dotnet restore "Zthombe-API/Zthombe-API.csproj"
COPY . .
WORKDIR "/src/Zthombe-API"
RUN dotnet build "Zthombe-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zthombe-API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zthombe-API.dll"]