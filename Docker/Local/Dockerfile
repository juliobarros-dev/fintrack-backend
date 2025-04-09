# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia a solution e os projetos
COPY ../../FinTrack.sln ./
COPY ../../FinTrack.Application.WebApi ./FinTrack.Application.WebApi
COPY ../../FinTrack.Domain.Models ./FinTrack.Domain.Models
COPY ../../FinTrack.Infrastructure.Database ./FinTrack.Infrastructure.Database

# Restaura e publica
WORKDIR /app/FinTrack.Application.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o /out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "FinTrack.Application.WebApi.dll"]
