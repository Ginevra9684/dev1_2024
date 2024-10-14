dotnet tool install --global dotnet-aspnet-codegenerator
dotnet-aspnet-codegenerator
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet aspnet-codegenerator identity -dc MvcAuthApp.Data.ApplicationDbContext --files "Account.Register"