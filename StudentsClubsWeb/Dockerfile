# StudentsClubsWeb - ASP.NET Core 10 LTS MVC + SQLite
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY StudentsClubsWeb.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish StudentsClubsWeb.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish ./
# Run as the image's unprivileged 'app' user; it owns /app so SQLite can
# write its journal next to the bundled database.
RUN chown -R $APP_UID /app
USER $APP_UID
# Bind to 8080 (non-root friendly) and run behind Coolify/Traefik
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
# Honor X-Forwarded-Proto/For from the reverse proxy so HTTPS redirect doesn't loop
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
# SQLite database shipped inside the image (already seeded with demo data)
ENV ConnectionStrings__DefaultConnection="Data Source=/app/Data/Db/main.db"
EXPOSE 8080
ENTRYPOINT ["dotnet", "StudentsClubsWeb.dll"]
