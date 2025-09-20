# sprint-1-activity-4

# hidden

**hidden** is an ASP.NET Core web application (MVC / Razor) built on **.NET 8.0**.  
This repository contains a small web app with controllers, views, and environment-based configuration, designed as a learning base or as a template to extend with features (users, contact/resident info, etc.).

---

## Quick Overview
- **Technology:** C# / ASP.NET Core (net8.0)  
- **Pattern:** MVC + Razor Pages (mix of controllers and `.cshtml` / `.cshtml.cs` pages)  
- **Key Dependencies:** Entity Framework Core (included in the `csproj`)  
- **Configuration:** `appsettings.json` and `appsettings.Development.json`  
- **Recommended IDE:** Visual Studio 2022 / Rider / VS Code  

---

## What’s Inside?

### Main Files
- `Program.cs` — Entry point, middleware, routing, and static files configuration.  
- `hidden.csproj` — Project definition (SDK-style .NET project).  
- `appsettings.json` — Global configuration (logging, connection strings).  
- `appsettings.Development.json` — Development environment configuration.  

### Key Folders
- `Controllers/` — MVC Controllers:
  - `HomeController.cs`
  - `InfoContactController.cs`
  - `InfoResidentController.cs`
  - `UsersController.cs`

- `Models/` — Models:
  - `ErrorViewModel.cs`

- `Views/` — Razor views and pages:
  - `Views/Home/Index.cshtml`
  - `Views/Home/Privacy.cshtml`
  - `Views/InfoContact/Show.cshtml` + `Show.cshtml.cs`
  - `Views/InfoResident/Show.cshtml` + `Show.cshtml.cs`
  - `Views/Users/Index.cshtml` + `Index.cshtml.cs`
  - `Views/Users/Show.cshtml` + `Show.cshtml.cs`
  - `Views/Shared/Error.cshtml`
  - `Views/Shared/_Layout.cshtml` + `_Layout.cshtml.css`
  - `Views/Shared/_ValidationScriptsPartial.cshtml`
  - `Views/_ViewImports.cshtml`
  - `Views/_ViewStart.cshtml`

- `.idea/` — JetBrains Rider IDE settings (if used).  

---

## Prerequisites
1. **.NET 8 SDK** (download: https://dotnet.microsoft.com/download/dotnet/8.0)  
2. (Optional) **SQL Server / LocalDB**, if you want to use the provided `ConnectionStrings` in `appsettings.json`.  
   Example connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MiProyectoDB;Trusted_Connection=True;"
   }
If you don’t use EF Core/DB, the app can still run (depending on whether DbContext is used at runtime).

Install & Run (Local)
Open a terminal at the project root (hidden/) and run:

bash
Copiar código
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run in development mode
dotnet run
By default, ASP.NET Core exposes the app at http://localhost:5xxx (check console output).

Force a custom port:

bash
Copiar código
dotnet run --urls "http://localhost:5000"
Run in a specific environment:

bash
Copiar código
ASPNETCORE_ENVIRONMENT=Development dotnet run
(PowerShell: $Env:ASPNETCORE_ENVIRONMENT = "Development"; dotnet run)

Example Routes
/ → HomeController.Index → Views/Home/Index.cshtml

/Home/Privacy → HomeController.Privacy

/Users → UsersController.Index → Views/Users/Index.cshtml

/Users/Show → UsersController.Show → Views/Users/Show.cshtml

/InfoContact/Show → InfoContactController.Show

/InfoResident/Show → InfoResidentController.Show

Routes usually follow the {controller}/{action}/{id?} pattern defined in Program.cs with MapControllerRoute.

Configuration (appsettings.json)
Includes Logging and ConnectionStrings.

Update DefaultConnection if you plan to use EF Core.

If not using EF Core, you can safely ignore/remove that section.

Publishing
To publish in Release mode:

bash
Copiar código
dotnet publish -c Release -o ./publish
The build will be in ./publish, ready for deployment to IIS, Azure App Service, or Docker.

EF Core Notes
The .csproj includes:

Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools

If you use a database:

bash
Copiar código
dotnet ef migrations add InitialCreate
dotnet ef database update
These commands require a properly configured DbContext and migrations.

Development & Extension
Add a new Controller: place it in Controllers/, inherit from Controller, and create matching views in Views/<ControllerName>/.

Add a Model: define it in Models/.

Razor Pages with logic: use .cshtml + .cshtml.cs (examples: Views/Users, Views/InfoResident).

Static files (CSS/JS): use a wwwroot/ folder and ensure app.UseStaticFiles() is enabled in Program.cs.

File Responsibilities
Program.cs — Configures middleware, services, and routing.

Controllers/* — Handle HTTP requests and actions.

Views/* — Razor templates to render HTML.

Models/* — ViewModels / DTOs (currently ErrorViewModel).

appsettings*.json — Environment-specific configuration.
