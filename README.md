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
* Framework used:
  - Microsoft.EntityFrameworkCoreDesign
  - Microsoft.EntityFrameworkCoreTool
  - Microsoft.AspNetCore.Authentication.JwtBearer
#### Service
* Framework used:
  - Microsoft.EntityFrameworkCoreDesign
  - Microsoft.EntityFrameworkCoreTool
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.postgreSQL
  - Microsoft.AspNetCore.Authentication.JwtBearer
#### Repository
* Framework used:
  - Microsoft.EntityFrameworkCore.postgreSQL
