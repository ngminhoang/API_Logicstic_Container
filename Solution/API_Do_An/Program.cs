using Microsoft.EntityFrameworkCore;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.Repositories;
using Services_Do_An.AutoMapper;
using Services_Do_An.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add DB
builder.Services.AddDbContext<Repositories_Do_An.DBcontext_vs_Entities.CFcontext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//Add Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Add DI container
builder.Services.AddTransient<IServices<AdminModel>,AdminService>();
builder.Services.AddTransient<IRepository<Admin>, AdminRepository>();
builder.Services.AddTransient<IRepository<AppRate>, AppRateRepository>();
builder.Services.AddTransient<IRepository<Bussiness>, BussinessRepository>();
builder.Services.AddTransient<IRepository<Contract>, ContractRepository>();
builder.Services.AddTransient<IRepository<ContractType>, ContractTypeRepository>();
builder.Services.AddTransient<IRepository<Counting>, CountingRepository>();
builder.Services.AddTransient<IRepository<Customer>, CustomerRepository>();
builder.Services.AddTransient<IRepository<Driver>, DriverRepository>();
builder.Services.AddTransient<IRepository<DriverRate>, DriverRateRepository>();
builder.Services.AddTransient<IRepository<Invoice>, InvoiceRepository>();
builder.Services.AddTransient<IRepository<Message>, MessageRepository>();
builder.Services.AddTransient<IRepository<Notification>, NotificationRepository>();
builder.Services.AddTransient<IRepository<NotifType>, NotifTypeRepository>();
builder.Services.AddTransient<IRepository<Order>, OrderRepository>();
builder.Services.AddTransient<IRepository<OrderItem>, OrderItemRepository>();
builder.Services.AddTransient<IRepository<OrderStatus>, OrderStatusRepository>();
builder.Services.AddTransient<IRepository<Owner>, OwnerRepository>();
builder.Services.AddTransient<IRepository<Position>, PositionRepository>();
builder.Services.AddTransient<IRepository<Role>, RoleRepository>();
builder.Services.AddTransient<IRepository<Staff>, StaffRepository>();
builder.Services.AddTransient<IRepository<Status>, StatusRepository>();
builder.Services.AddTransient<IRepository<Vihcle>, VihcleRepository>();
builder.Services.AddTransient<IRepository<Warehouse>, WarehouseRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
