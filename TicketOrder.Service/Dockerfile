FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TicketOrder.Service/TicketOrder.Service.csproj", "TicketOrder.Service/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["EventStore.Middleware/EventStore.Middleware.csproj", "EventStore.Middleware/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Ticket.Entityframework.ReadStore/Ticket.Entityframework.ReadStore.csproj", "Ticket.Entityframework.ReadStore/"]
RUN dotnet restore "TicketOrder.Service/TicketOrder.Service.csproj"
COPY . .
WORKDIR "/src/TicketOrder.Service"
RUN dotnet build "TicketOrder.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TicketOrder.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TicketOrder.Service.dll"]