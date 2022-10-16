using Angular_link_to_DB_API.Data;
using Angular_link_to_DB_API.Db;
using Angular_link_to_DB_API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<DBHelper>();
builder.Services.AddScoped<Utils>();

builder.Services.AddControllers();

builder.Services.AddDbContext<CadetDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ECMConnection")));
builder.Services.AddDbContext<CadetAuditTrailDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ECMConnection")));
builder.Services.AddDbContext<TestingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ECMConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Angular Link To DB"
    });
});

//builder.Services.AddDbContext<DbContent>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LinkToDbConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
