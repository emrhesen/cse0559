FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["EventStore.App/EventStore.App.csproj", "EventStore.App/"]
COPY ["EventStore.Middleware/EventStore.Middleware.csproj", "EventStore.Middleware/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "EventStore.App/EventStore.App.csproj"
COPY . .
WORKDIR "/src/EventStore.App"
RUN dotnet build "EventStore.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EventStore.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventStore.App.dll"]