FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Movie.Service/Movie.Service.csproj", "Movie.Service/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["EventStore.Middleware/EventStore.Middleware.csproj", "EventStore.Middleware/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Movie.Entityframework.ReadStore/Movie.Entityframework.ReadStore.csproj", "Movie.Entityframework.ReadStore/"]
RUN dotnet restore "Movie.Service/Movie.Service.csproj"
COPY . .
WORKDIR "/src/Movie.Service"
RUN dotnet build "Movie.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Movie.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Movie.Service.dll"]