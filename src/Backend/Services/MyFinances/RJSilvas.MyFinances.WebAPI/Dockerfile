#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Backend/Services/MyFinances/RJSilvas.MyFinances.WebAPI/RJSilvas.MyFinances.WebAPI.csproj", "RJSilvas.MyFinances.WebAPI/"]
RUN dotnet restore "RJSilvas.MyFinances.WebAPI/RJSilvas.MyFinances.WebAPI.csproj"
COPY src/Backend/Services/MyFinances/ .
WORKDIR "/src/RJSilvas.MyFinances.WebAPI"
RUN dotnet build "RJSilvas.MyFinances.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RJSilvas.MyFinances.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RJSilvas.MyFinances.WebAPI.dll"]