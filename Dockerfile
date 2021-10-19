FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY ["src/merchandise-service.csproj","src/"]

RUN dotnet restore "src/merchandise-service.csproj"

COPY . .
WORKDIR "/src/src"
RUN dotnet build "merchandise-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "merchandise-service.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app

EXPOSE 80

FROM runtime AS final 
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "merchandise-service.dll"]