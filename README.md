# Đồ án Web nâng cao: phần Backend
## Introduce:
 - Nội dung đồ án là xây dựng một Website hỗ trợ việc môi giới giữa khách hàng và tài xế vận chuyển
 - Đồ án xây dựng với Backend sử dụng ASP.NET core web API theo mô hình REST và hệ cơ sở dữ liệu PostgreSQL để quản lý và cung cấp dịch vụ cho phía Frontend.
## Description:
 - Xây dựng các MasterData như Tài khoản, Đơn hàng, Hóa đơn,...
 - Thiết lập Xác thực và Phân quyền: bao gồm 5 role: Admin, Staff, Customer, Driver, Business.
 - Xây dựng CRUD API cho các MasterData.
## Technical Stack:
### DB: PostgreSQL
### BE: .NET 7.0
* Basic command:
  ```
  dotnet ef migrations add <MigrationName>
  dotnet ef database update
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
