FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Prifiler.Api/Prifiler.Api.csproj", "Prifiler.Api/"]
RUN dotnet restore "Prifiler.Api/Prifiler.Api.csproj"
COPY . .
WORKDIR "/src/Prifiler.Api"
RUN dotnet build "Prifiler.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prifiler.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prifiler.Api.dll"]
