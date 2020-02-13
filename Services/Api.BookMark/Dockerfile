FROM mcr.microsoft.com/dotnet/core/sdk:3.1.100-alpine AS build
WORKDIR /app
EXPOSE 80

# copy dependency
COPY Shared/Data.Shared/Data.Shared.csproj Shared/Data.Shared/ 
COPY Shared/Api.Shared/Api.Shared.csproj Shared/Api.Shared/ 
COPY Services/Data.BookMark/Data.BookMark.csproj Services/Data.BookMark/ 
COPY Services/Api.BookMark/Api.BookMark.csproj Services/Api.BookMark/ 

RUN dotnet restore Services/Api.BookMark/Api.BookMark.csproj 

# copy and publish
COPY . .
WORKDIR /app/Services/Api.BookMark
RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.0-alpine
WORKDIR /app
COPY --from=build /app/Services/Api.BookMark/out ./
ENTRYPOINT ["dotnet", "Api.BookMark.dll"]