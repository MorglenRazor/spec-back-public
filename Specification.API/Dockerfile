# Stage 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем sln и csproj всех проектов
COPY Specification.sln ./
COPY Specification.API/Specification.API.csproj Specification.API/
COPY Specification.Application/Specification.Application.csproj Specification.Application/
COPY Specification.Core/Specification.Core.csproj Specification.Core/
COPY Specification.DataAccess/Specification.DataAccess.csproj Specification.DataAccess/
COPY Specification.Infrastructure/Specification.Infrastructure.csproj Specification.Infrastructure/

# Восстанавливаем зависимости
RUN dotnet restore Specification.sln

# Копируем весь остальной код решения
COPY Specification.API/ Specification.API/
COPY Specification.Application/ Specification.Application/
COPY Specification.Core/ Specification.Core/
COPY Specification.DataAccess/ Specification.DataAccess/
COPY Specification.Infrastructure/ Specification.Infrastructure/

# Публикуем API проект
WORKDIR /src/Specification.API
RUN dotnet publish -c Release -o /app/publish

# Stage 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 5000
ENTRYPOINT ["dotnet", "Specification.API.dll"]