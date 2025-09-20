# sprint-1-activity-4

# hidden

**hidden** es una aplicación web ASP.NET Core (MVC / Razor) desarrollada sobre **.NET 8.0**.  
Este repositorio contiene una pequeña aplicación web con controladores, vistas y configuración por entornos, pensada como base para aprendizaje o como plantilla para extender funcionalidades (usuarios, información de contacto/residentes, etc.).

---

## Resumen rápido
- **Tecnología:** C# / ASP.NET Core (net8.0)  
- **Patrón:** MVC + Razor Pages (mezcla de controllers y páginas .cshtml/.cshtml.cs)  
- **Dependencias importantes:** Entity Framework Core (paquetes incluidos en el `csproj`)  
- **Configuración:** `appsettings.json` y `appsettings.Development.json`  
- **IDE recomendado:** Visual Studio 2022 / Rider / VS Code

---

## ¿Qué contiene el proyecto?

### Archivos principales
- `Program.cs` — Punto de entrada y configuración del pipeline (routing, static files, endpoints).
- `hidden.csproj` — Definición del proyecto (.NET SDK style).
- `appsettings.json` — Configuración global (logging, connectionstrings).
- `appsettings.Development.json` — Configuración para entorno de desarrollo.

### Carpetas relevantes
- `Controllers/` — Controladores MVC:
  - `Controllers/HomeController.cs`
  - `Controllers/InfoContactController.cs`
  - `Controllers/InfoResidentController.cs`
  - `Controllers/UsersController.cs`

- `Models/` — Modelos:
  - `Models/ErrorViewModel.cs`

- `Views/` — Vistas y páginas Razor:
  - `Views/Home/Index.cshtml`
  - `Views/Home/Privacy.cshtml`
  - `Views/InfoContact/Show.cshtml`
  - `Views/InfoContact/Show.cshtml.cs`
  - `Views/InfoResident/Show.cshtml`
  - `Views/InfoResident/Show.cshtml.cs`
  - `Views/Shared/Error.cshtml`
  - `Views/Shared/_Layout.cshtml`
  - `Views/Shared/_Layout.cshtml.css`
  - `Views/Shared/_ValidationScriptsPartial.cshtml`
  - `Views/Users/Index.cshtml`
  - `Views/Users/Index.cshtml.cs`
  - `Views/Users/Show.cshtml`
  - `Views/Users/Show.cshtml.cs`
  - `Views/_ViewImports.cshtml`
  - `Views/_ViewStart.cshtml`

- `.idea/` — Configuración del IDE JetBrains Rider (si trabajaste con Rider).

---

## Requisitos previos

1. **.NET 8 SDK** (instala desde https://dotnet.microsoft.com/download/dotnet/8.0)  
2. (Opcional) **SQL Server / LocalDB**, si decides activar/usar la `ConnectionStrings` que hay en `appsettings.json`.  
   - `appsettings.json` contiene una cadena:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MiProyectoDB;Trusted_Connection=True;"
     }
     ```
   - Si no vas a usar EF Core/DB, la aplicación puede ejecutarse sin que exista la DB (dependiendo de si el código intenta usar el contexto en tiempo de ejecución).

---

## Instalar y ejecutar (local)

Abre una terminal en la raíz del proyecto (`hidden/`) y ejecuta:

```bash
# Restaurar paquetes
dotnet restore

# Compilar
dotnet build

# Ejecutar en modo desarrollo
dotnet run
Por defecto la aplicación expondrá la URL indicada por ASP.NET Core (normalmente http://localhost:5xxx o la que muestre la consola).

Para forzar un puerto:

bash
Copiar código
dotnet run --urls "http://localhost:5000"
Ejecutar en un entorno específico
Para ejecutar en modo Development:

bash
Copiar código
ASPNETCORE_ENVIRONMENT=Development dotnet run
(en Windows PowerShell: $Env:ASPNETCORE_ENVIRONMENT = "Development"; dotnet run)

Rutas de ejemplo (lo habitual en un MVC)
/ → HomeController.Index (vista Views/Home/Index.cshtml)

/Home/Privacy → HomeController.Privacy

/Users → UsersController.Index / Views/Users/Index.cshtml

/Users/Show → UsersController.Show / Views/Users/Show.cshtml

/InfoContact/Show → InfoContactController.Show

/InfoResident/Show → InfoResidentController.Show

Dependiendo de cómo está definido Program.cs y el MapControllerRoute, las rutas pueden seguir el formato {controller}/{action}/{id?}.

Uso de la configuración (appsettings.json)
appsettings.json ya incluye Logging y ConnectionStrings. Revisa y adapta el valor de DefaultConnection si vas a usar EF Core (o borra/ignora la sección si no se usa).

Publicación
Para publicar en modo Release:

bash
Copiar código
dotnet publish -c Release -o ./publish
El contenido quedará en ./publish. Luego puedes desplegarlo en IIS, Azure App Service, Docker, etc.

Notas sobre EF Core
El .csproj incluye referencias a:

Microsoft.EntityFrameworkCore

Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore.Tools

Si vas a usar la base de datos:

Asegúrate de tener configurado el DbContext y de que el código tenga las migraciones.

Comandos típicos (desde la carpeta del proyecto):

bash
Copiar código
dotnet ef migrations add InitialCreate
dotnet ef database update
Si no has añadido un DbContext ni migraciones, esos comandos no se aplicarán hasta que se implementen.

Desarrollo y extensión
Para añadir un nuevo controlador: agrega un archivo en Controllers/, hereda de Controller y crea vistas en Views/<ControllerName>/.

Para modelos: agrégalos en Models/.

Para vistas con lógica (Razor Page model): puedes tener .cshtml + .cshtml.cs (ya hay ejemplos en Views/Users y Views/InfoResident).

Static files (CSS/JS): usa la carpeta wwwroot/ (si la creas) y llama a app.UseStaticFiles() (probablemente ya configurado en Program.cs).

Resumen de responsabilidades de archivos detectados
Program.cs — Configura middleware, servicios y rutas.

Controllers/* — Lógica de entrada HTTP / acciones.

Views/* — Plantillas Razor para renderizar HTML.

Models/* — DTOs / ViewModels (actual: ErrorViewModel).

appsettings*.json — Configuración por entorno.
