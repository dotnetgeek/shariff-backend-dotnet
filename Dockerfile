FROM microsoft/aspnetcore:1.0.1

# Set ASP.NET Core environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Production"

ADD ./artifacts /app

WORKDIR /app

EXPOSE 5000

ENTRYPOINT ["dotnet", "src.dll"]
