#Settings:
- appsettings.json - set db user and password (Pgsql)

#API:
- dotnet add package Microsoft.EntityFrameworkCore.Design

#Infrastructure:
- dotnet ef database update -s ..\MicroLMS.API

#Frontend:
- dotnet watch (for dev front server)