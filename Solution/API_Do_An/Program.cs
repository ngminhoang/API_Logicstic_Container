using API_Do_An;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Users;
using Repositories_Do_An.Repositories;
using Services_Do_An.AutoMapper;
using Services_Do_An.IServices;
using Services_Do_An.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add DB
builder.Services.AddDbContext<Repositories_Do_An.DBcontext_vs_Entities.CFcontext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//Add Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add DI container
builder.Services.AddTransient<IAdminService,AdminService>();
builder.Services.AddTransient<IRoleService, RoleService>();
builder.Services.AddTransient<IStaffService, StaffService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IDriverService, DriverService>();
builder.Services.AddTransient<IBussinessService, BussinessService>();

builder.Services.AddTransient<IAdminRepository, AdminRepository>();
builder.Services.AddTransient<IAppRateRepository, AppRateRepository>();
builder.Services.AddTransient<IBussinessRepository, BussinessRepository>();
builder.Services.AddTransient<IContractRepository, ContractRepository>();
builder.Services.AddTransient<IContractTypeRepository, ContractTypeRepository>();
builder.Services.AddTransient<ICountingRepository, CountingRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IDriverRepository, DriverRepository>();
builder.Services.AddTransient<IDriverRateRepository, DriverRateRepository>();
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<INotificationRepository, NotificationRepository>();
builder.Services.AddTransient<INotifTypeRepository, NotifTypeRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddTransient<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddTransient<IOwnerRepository, OwnerRepository>();
builder.Services.AddTransient<IPositionRepository, PositionRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IStaffRepository, StaffRepository>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IWarehouseRepository, WarehouseRepository>();



//authen vs author

var key = builder.Configuration["Jwt:Key"];
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme
    ).AddJwtBearer(options =>
    {
        IConfigurationSection jwtSettings = builder.Configuration.GetSection("JwtSettings");
        string secretKey = jwtSettings["SecretKey"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],

            RequireExpirationTime = true,
            ValidateLifetime = true,

            //ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,
            RequireSignedTokens = true,
            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        };
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireRole("admin"));
    options.AddPolicy("driver", policy => policy.RequireRole("driver"));
    options.AddPolicy("staff", policy => policy.RequireRole("staff"));
    options.AddPolicy("customer", policy => policy.RequireRole("customer"));
    options.AddPolicy("bussiness", policy => policy.RequireRole("bussiness"));
});




//builder.Services.AddControllers();
builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
            });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Thêm xác thực JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },

            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/**/
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
