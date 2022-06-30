#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VxTel.WebSite/VxTel.WebSite.csproj", "VxTel.WebSite/"]
RUN dotnet restore "VxTel.WebSite/VxTel.WebSite.csproj"
COPY . .
WORKDIR "/src/VxTel.WebSite"
RUN dotnet build "VxTel.WebSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VxTel.WebSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VxTel.WebSite.dll"]