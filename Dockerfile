FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["htmx-first-run.csproj", "./"]
RUN dotnet restore "htmx-first-run.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "htmx-first-run.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "htmx-first-run.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "htmx-first-run.dll"]
