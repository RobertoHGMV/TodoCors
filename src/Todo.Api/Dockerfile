# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY src/Todo.Api/*.csproj ./src/Todo.Api/
COPY src/Todo.DependencyInjection/*.csproj ./src/Todo.DependencyInjection/
COPY src/Todo.Infra/*.csproj ./src/Todo.Infra/
COPY src/Todo.Domain/*.csproj ./src/Todo.Domain/
COPY src/Todo.Common/*.csproj ./src/Todo.Common/
COPY src/Todo.Tests/*.csproj ./src/Todo.Tests/

RUN dotnet restore

# Copy everything else and build
COPY src/Todo.Api/. ./src/Todo.Api/
COPY src/Todo.DependencyInjection/. ./src/Todo.DependencyInjection/
COPY src/Todo.Infra/. ./src/Todo.Infra/
COPY src/Todo.Domain/. ./src/Todo.Domain/
COPY src/Todo.Common/. ./src/Todo.Common/

WORKDIR /app/src/Todo.Api
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app

COPY --from=build-env /app/src/Todo.Api/out ./
ENTRYPOINT ["dotnet", "Todo.Api.dll"]