# ENTITY FRAMEWORK

- dotnet add package Microsoft.EntityFrameworkCore;
- oppure dotnet add package Microsoft.EntityFrameworkCore.Sqlite;
- dotnet run
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet tool install --global dotnet-ef
- dotnet ef migrations add InitialCreate
- dotnet ef database update