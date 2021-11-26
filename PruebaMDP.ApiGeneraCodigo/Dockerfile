#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PruebaMDP.ApiGeneraCodigo/PruebaMDP.ApiCupones.csproj", "PruebaMDP.ApiGeneraCodigo/"]
COPY ["Application/PruebaMDP.Application.csproj", "Application/"]
COPY ["PruebaMDP.Entities/PruebaMDP.Entities.csproj", "PruebaMDP.Entities/"]
COPY ["PruebaMDP.Abstraction/PruebaMDP.Abstraction.csproj", "PruebaMDP.Abstraction/"]
COPY ["PruebaMDP.Services/PruebaMDP.Services.csproj", "PruebaMDP.Services/"]
COPY ["PruebaMDP.Repository/PruebaMDP.Repository.csproj", "PruebaMDP.Repository/"]
COPY ["PruebaMDP.DataAccess/PruebaMDP.DataAccess.csproj", "PruebaMDP.DataAccess/"]
RUN dotnet restore "PruebaMDP.ApiGeneraCodigo/PruebaMDP.ApiCupones.csproj"
COPY . .
WORKDIR "/src/PruebaMDP.ApiGeneraCodigo"
RUN dotnet build "PruebaMDP.ApiCupones.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PruebaMDP.ApiCupones.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PruebaMDP.ApiCupones.dll"]