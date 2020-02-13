FROM mcr.microsoft.com/dotnet/core/sdk:3.1.100-alpine AS build
WORKDIR /app
EXPOSE 80

# copy csproj (inc. dependencies) and restore as distinct layers
COPY Api.Gateway/Api.Gateway.csproj Api.Gateway/

RUN dotnet restore Api.Gateway/Api.Gateway.csproj

# copy and publish app and libraries
COPY . .
WORKDIR /app/Api.Gateway
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.0-alpine
WORKDIR /app
COPY --from=build /app/Api.Gateway/out ./
ENTRYPOINT ["dotnet", "Api.Gateway.dll"]
