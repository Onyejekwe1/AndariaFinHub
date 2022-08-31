#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/AndariaFinHub.Api/AndariaFinHub.Api.csproj", "src/Apps/AndariaFinHub.Api/"]
COPY ["src/Common/AndariaFinHub.Infrastructure/AndariaFinHub.Infrastructure.csproj", "src/Common/AndariaFinHub.Api.Infrastructure/"]
COPY ["src/Common/AndariaFinHub.Application/AndariaFinHub.Application.csproj", "src/Common/AndariaFinHub.Api.Application/"]
COPY ["src/Common/AndariaFinHub.Domain/AndariaFinHub.Domain.csproj", "src/Common/AndariaFinHub.Api.Domain/"]
RUN dotnet restore "src/Apps/AndariaFinHub.Api/AndariaFinHub.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/AndariaFinHub.Api"
RUN dotnet build "AndariaFinHub.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AndariaFinHub.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AndariaFinHub.Api.dll"]