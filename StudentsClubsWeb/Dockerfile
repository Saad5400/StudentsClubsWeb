# StudentsClubsWeb - ASP.NET Core 6 MVC + SQLite
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY StudentsClubsWeb.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish StudentsClubsWeb.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/publish ./
# Bind to 8080 (non-root friendly) and run behind Coolify/Traefik
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
# Honor X-Forwarded-Proto/For from the reverse proxy so HTTPS redirect doesn't loop
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
# SQLite database shipped inside the image (already seeded with demo data)
ENV ConnectionStrings__DefaultConnection="Data Source=/app/Data/Db/main.db"
EXPOSE 8080
ENTRYPOINT ["dotnet", "StudentsClubsWeb.dll"]
