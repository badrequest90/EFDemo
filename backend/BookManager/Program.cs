using System;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// use the connection string in the appsettings.json
builder.Services.AddDbContext<BookManagerContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI for book services
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// DI for order services
builder.Services.AddScoped<IOrderService, OrderService>();

// DI for system services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();

//Add controllers to DI container and configure circular reference handler
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    }
);

builder.Services.Configure<CryptographyOptions>(builder.Configuration.GetSection("Argon2Settings"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// continue the build process
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseRouting();
app.MapControllers();
app.Run();
