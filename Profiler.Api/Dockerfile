FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IntegrationEventLogEF/IntegrationEventLogEF.csproj", "IntegrationEventLogEF/"]
COPY ["Profiler.Domain/Profiler.Domain.csproj", "Profiler.Domain/"]
COPY ["Profiler.Infrastructure/Profiler.Infrastructure.csproj", "Profiler.Infrastructure/"]
COPY ["Profiler.UnitTests/Profiler.UnitTests.csproj", "Profiler.UnitTests/"]
COPY ["Profiler.Api/Profiler.Api.csproj", "Profiler.Api/"]
RUN dotnet restore "Profiler.Api/Profiler.Api.csproj"
COPY . .
WORKDIR "/src/Profiler.Api"
RUN dotnet build "Profiler.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Profiler.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Profiler.Api.dll"]
