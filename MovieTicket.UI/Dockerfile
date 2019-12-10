FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mjibrandl/dotnetcore-angular:latest AS build
WORKDIR /src
COPY ["MovieTicket.UI/MovieTicket.UI.csproj", "MovieTicket.UI/"]
RUN dotnet restore "MovieTicket.UI/MovieTicket.UI.csproj"
COPY . .
WORKDIR "/src/MovieTicket.UI"
RUN dotnet build "MovieTicket.UI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MovieTicket.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MovieTicket.UI.dll"]