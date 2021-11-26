#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PruebaMDP.WebPromociones/PruebaMDP.WebPromociones.csproj", "PruebaMDP.WebPromociones/"]
RUN dotnet restore "PruebaMDP.WebPromociones/PruebaMDP.WebPromociones.csproj"
COPY . .
WORKDIR "/src/PruebaMDP.WebPromociones"
RUN dotnet build "PruebaMDP.WebPromociones.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaMDP.WebPromociones.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaMDP.WebPromociones.dll"]