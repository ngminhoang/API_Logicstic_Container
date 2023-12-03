using API_Do_An;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories_Do_An.DBcontext_vs_Entities;
using Repositories_Do_An.IRepositories;
using Repositories_Do_An.IRepositories.Others;
using Repositories_Do_An.IRepositories.Users;
using Repositories_Do_An.Repositories;
using Repositories_Do_An.Repositories.Others;
using Serilog;
using Serilog.Formatting.Json;
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
builder.Services.AddScoped<IAdminService,AdminService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IBussinessService, BussinessService>();
builder.Services.AddScoped<IPublicService, PublicService>();

builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IAppRateRepository, AppRateRepository>();
builder.Services.AddScoped<IBussinessRepository, BussinessRepository>();
builder.Services.AddScoped<ICountingRepository, CountingRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<IDriverRateRepository, DriverRateRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddScoped<IOwnedVehicleInforRepository, OwnedVehicleInforRepository>();
builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IWishedAcceptedDriverListRepository, WishedAcceptedDriverListRepository>();
builder.Services.AddScoped<IContactionRepository, ContactionRepository>();

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


var x = "MyAllowSpecificOrigins";
builder.Services.AddCors(
    options => options.AddPolicy(name: x, builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    }
    ));



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


builder.Host.UseSerilog((ttx, config) =>
{
    config.WriteTo.Console().MinimumLevel.Information();
    config.WriteTo.File(
        path: AppDomain.CurrentDomain.BaseDirectory + "/logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        rollOnFileSizeLimit: true,
        formatter: new JsonFormatter()
        ).MinimumLevel.Information();
}
);

var app = builder.Build();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Serve static files
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "_assets")),
    RequestPath = "/assets",
    ServeUnknownFileTypes = true
});

app.UseCors (x);

app.UseHttpsRedirection();

/**/
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
