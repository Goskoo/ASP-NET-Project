# Mineral Catalog

An ASP.NET Core MVC web application for browsing and managing a catalog of minerals, the locations where they are found, and the museums where they are displayed.

> Built as the ASP.NET Fundamentals project assignment.

## Features

- Browse all minerals with their name, category and colors
- View a mineral's full details: physical properties (Name, category, colors, luster, transparency, mohs scale, crystal system, crystal habit, cleavage, fracture and streak), description, collecting tips and processing tips
- Full CRUD for minerals add, view, edit and delete
- Link each mineral to the locations where it is found and the museums that display it
- Browse locations (country, region, mining history, active mining site) and see the minerals found in each
- Browse museums (city, country, description) and see the minerals they hold
- Server-side and client-side validation with clear error messages
- Responsive layout using Bootstrap
- Seed data (locations, museums, minerals) included, so the app has content on first run

## Technologies

- C# and ASP.NET Core MVC (.NET version 8.0)
- Entity Framework Core with SQL Server
- Razor views with a shared layout, partial views and sections
- Bootstrap 5, jQuery and jQuery Validation
- Dependency Injection

## Data Model

 Entity       | Main properties                                                                                       
 ------------ | ----------------------------------------------------------------------------------------------------- 
 **Mineral**  | Name, Category, Colors, Luster, Transparency, Mohs scale, Crystal system, Habit, Cleavage, Fracture, Streak, Description, Collecting tips, Processing tips 
 **Location** | Country, Region name, Mining history notes, Is active mining site                                     
 **Museum**   | Name, City, Country, Description                                                                      

Relationships:

- A mineral can be found in many locations, and a location can have many minerals (many-to-many)
- A mineral can be displayed in many museums, and a museum can hold many minerals (many-to-many)

## Architecture

The project follows the MVC pattern with a service layer:

- **Controllers** handle requests and return views or redirects
- **Services** (`IMineralService`, `ILocationService`, `IMuseumService`) contain the data access logic and are injected into the controllers
- **ViewModels** (`MineralFormViewModel`) carry form data and validation rules
- **Data** contains the entities, enums, validation constants, entity configurations (including seed data) and the `DbContext`

### Project structure

```
ASP_NET_Project
	Controllers
	Data
		Configurations
		Constants
		Enum
		Models
		MineralApplicationDbContext.cs
	Services
	ViewModels
	Views
		Home
		Location
		Mineral
		Museum
		Shared
 Program.cs
```


## Getting Started

### Prerequisites

- .NET 8 SDK(https://dotnet.microsoft.com/download) 
- SQL Server
- Optional: Visual Studio 2022 or later
- Optional: Git
- EF Core command-line tool (only if you use the terminal):

  ```
  dotnet tool install --global dotnet-ef
  ```

### Setup

1. **Clone the repository** (choose one)
- Terminal
   ```
	 git clone https://github.com/Goskoo/ASP-NET-Project
	 cd ASP-NET-Project
   ```
- GitHub Website : click the Code button then Download ZIP and extract the archive.
- Visual Studio  : Choose Clone a repository on the start window and paste `https://github.com/Goskoo/ASP-NET-Project`

2. **Check the connection string** in `appsettings.json`:
   ```
   "ConnectionStrings": {
     "SqlServer": "Server=.;Database=MineralDatabase;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
   }
   ```
   The default uses Windows authentication on the default local SQL Server instance (`Server=.`). If your SQL Server is different, change only the `Server=` part:

   | Setup                       | Server value                  |
   | --------------------------- | ----------------------------- |
   | Default instance (default)  | `.`                           |
   | SQL Server Express          | `.\\SQLEXPRESS`               |
   | LocalDB                     | `(localdb)\\MSSQLLocalDB`     |

3. **Create the database** 
   - Visual Studio, Package Manager Console:
     ```
	 Add-Migration InitialCreate
     Update-Database
     ```

4. **Run the application**

	 Press F5 in Visual Studio.
   
### Environment variables and credentials

- No user accounts, API keys or secrets are needed. The application has no login.
- The only configuration is the database connection string above. It uses Windows authentication (`Trusted_Connection=True`), so no SQL username or password is required.


## Validation

- Required fields and maximum lengths are defined with data annotations, with custom error messages
- Client-side validation uses jQuery Validation, and the same rules are checked again on the server
- Forms use anti-forgery tokens

## Author

Georgi Dimitrov

