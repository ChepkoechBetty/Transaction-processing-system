FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["TPS.csproj", "./"]
RUN dotnet restore "TPS.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "TPS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TPS.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TPS.dll"]
