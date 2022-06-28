#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VxTel.WebApi/VxTel.WebApi.csproj", "VxTel.WebApi/"]
RUN dotnet restore "VxTel.WebApi/VxTel.WebApi.csproj"
COPY . .
WORKDIR "/src/VxTel.WebApi"
RUN dotnet build "VxTel.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VxTel.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VxTel.WebApi.dll"]