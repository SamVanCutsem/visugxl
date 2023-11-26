FROM mcr.microsoft.com/dotnet/sdk
WORKDIR /src
COPY . .
 
RUN dotnet build -c Release
RUN dotnet test
RUN dotnet publish -o /publish
 
WORKDIR /publish
ENV ASPNETCORE_URLS=http://+:80/
EXPOSE 80
ENTRYPOINT ["dotnet", "MyAwesomeDotnetDockerApp.Web.dll"]
