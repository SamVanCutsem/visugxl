FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER $APP_UID
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80/;http://+:443/
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /src

COPY ["Nuget.Config", "."]
COPY Directory.Build.props ./
COPY Directory.Packages.props ./
COPY MyAwesomeDotnetDockerApp.sln ./
COPY src/Application/Application.csproj ./src/Application/
COPY src/Domain/Domain.csproj ./src/Domain/
COPY src/Web/Web.csproj ./src/Web/
COPY src/Infrastructure/Infrastructure.csproj ./src/Infrastructure/
COPY tests/Application.UnitTests/Application.UnitTests.csproj ./tests/Application.UnitTests/
COPY tests/Domain.UnitTests/Domain.UnitTests.csproj ./tests/Domain.UnitTests/

RUN dotnet restore 

# Copy all the source code files now
COPY . .
RUN dotnet build -c Release --no-restore
RUN dotnet test -c Release --no-build
RUN dotnet publish src/Web/Web.csproj -c Release --no-build -o /publish
 
FROM base AS final
WORKDIR /publish
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MyAwesomeDotnetDockerApp.Web.dll"]
