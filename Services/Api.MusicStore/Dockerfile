FROM mcr.microsoft.com/dotnet/core/sdk:3.1.100-alpine AS build
WORKDIR /app
EXPOSE 80

# copy dependency
COPY Shared/Data.Shared/Data.Shared.csproj Shared/Data.Shared/ 
COPY Shared/Api.Shared/Api.Shared.csproj Shared/Api.Shared/ 
COPY Services/Data.MusicStore/Data.MusicStore.csproj Services/Data.MusicStore/ 
COPY Services/Api.MusicStore/Api.MusicStore.csproj Services/Api.MusicStore/ 

RUN dotnet restore Services/Api.MusicStore/Api.MusicStore.csproj 

# copy and publish
COPY . .
WORKDIR /app/Services/Api.MusicStore
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.0-alpine
WORKDIR /app
COPY --from=build /app/Services/Api.MusicStore/out ./
ENTRYPOINT ["dotnet", "Api.MusicStore.dll"]