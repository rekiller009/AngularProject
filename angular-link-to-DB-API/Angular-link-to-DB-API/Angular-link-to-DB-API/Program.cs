using Angular_link_to_DB_API.Data;
using Angular_link_to_DB_API.Db;
using Angular_link_to_DB_API.Helpers;
using Angular_link_to_DB_API.OptionSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
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

builder.Services.ConfigureOptions<OptionSetup>();
builder.Services.ConfigureOptions<BearerOptionSetup>();
//builder.Services.AddDbContext<DbContent>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LinkToDbConnectionString")));


// Add Authorizaation
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddControllers(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

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

app.UseAuthentication();

app.MapControllers();

app.Run();
