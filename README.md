# Đồ án Web nâng cao: phần Backend
## Technical Stack:
### DB: PostgreSQL
### BE: .NET 7.0
* Basic command:
  ```
  dotnet new webapi -n <name> //create dotnet webapi app
  dotnet add package <packagename>
  dotnet new gitignore //create gitignore file
  dotnet run
  dotnet watch run
  ```
### Architecture layers
#### Controller
* Packages used:
  - AutoMapper.Extensions.Microsoft.DependencyInjection
  - Microsoft.EntityFrameworkCoreDesign
  - Microsoft.AspNetCore.Authentication.JwtBearer
  - Microsoft.AspNetCore.Identity.EntityFrameworkCore
  - Serilog.AspNetCore
#### Service
* Packages used:
  - AutoMapper.Extensions.Microsoft.DependencyInjection
#### Repository
* Packages used:
  - Microsoft.EntityFrameworkCore.PostgreSQL
  - Microsoft.EntityFrameworkCoreTool
  - Microsoft.EntityFrameworkCore
