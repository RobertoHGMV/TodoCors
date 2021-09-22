#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Todo.Api/Todo.Api.csproj", "src/Todo.Api/"]
COPY ["src/Todo.DependencyInjection/Todo.DependencyInjection.csproj", "src/Todo.DependencyInjection/"]
COPY ["src/Todo.Infra/Todo.Infra.csproj", "src/Todo.Infra/"]
COPY ["src/Todo.Domain/Todo.Domain.csproj", "src/Todo.Domain/"]
COPY ["src/Todo.Common/Todo.Common.csproj", "src/Todo.Common/"]
RUN dotnet restore "src/Todo.Api/Todo.Api.csproj"
COPY . .
WORKDIR "/src/src/Todo.Api"
RUN dotnet build "Todo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Api.dll"]