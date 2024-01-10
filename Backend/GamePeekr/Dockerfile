FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["GamePeekr.sln", "./"]

COPY ["GamePeekr/GamePeekr.csproj", "GamePeekr/"]
COPY ["GamePeekrReviewManagementDAL/GamePeekrReviewManagementDAL.csproj", "GamePeekrReviewManagementDAL/"]
COPY ["GamepeekrReviewManagement/GamepeekrReviewManagement.csproj", "GamepeekrReviewManagement/"]
COPY ["GamePeekrTest/GamePeekrTest.csproj", "GamePeekrTest/"]
COPY ["GamePeekrIntigrationTest/GamePeekrIntigrationTest.csproj", "GamePeekrIntigrationTest/"]
COPY ["GamePeekrEntityLayer/GamePeekrEntities.csproj", "GamePeekrEntityLayer/"]

RUN dotnet nuget locals all --clear

RUN dotnet restore

COPY . .

RUN dotnet build "GamePeekr.sln" -c Release --no-restore

FROM build AS publish
RUN dotnet publish "GamePeekr/GamePeekr.csproj" -c Release --no-restore -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GamePeekr.dll"]
