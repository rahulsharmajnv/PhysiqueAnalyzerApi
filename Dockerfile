FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PhysiqueAnalyzerApi.csproj", "./"]
RUN dotnet restore "./PhysiqueAnalyzerApi.csproj"
COPY . .
RUN dotnet publish "./PhysiqueAnalyzerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PhysiqueAnalyzerApi.dll"]