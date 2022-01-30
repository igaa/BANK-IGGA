#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BANK-IGGA/BANK-IGGA.csproj", "BANK-IGGA/"]
RUN dotnet restore "BANK-IGGA/BANK-IGGA.csproj"
COPY . .
WORKDIR "/src/BANK-IGGA"
RUN dotnet build "BANK-IGGA.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BANK-IGGA.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BANK-IGGA.dll"]