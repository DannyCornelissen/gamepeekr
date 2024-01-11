#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.



FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GamePeekr/GamePeekr.csproj", "GamePeekr/"]
RUN dotnet restore "GamePeekr/GamePeekr.csproj"
COPY . .
WORKDIR "/src/GamePeekr"
RUN dotnet build "GamePeekr.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GamePeekr.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=e2etesting
ENV ENV=e2etesting
ENTRYPOINT ["dotnet", "GamePeekr.dll"]