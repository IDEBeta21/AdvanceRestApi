//using AdvanceRestApi.Data;
using AdvanceRestApi.Interfaces;
using AdvanceRestApi.Profiles;
using AdvanceRestApi.Services;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddOData(option => option.Select().Filter().OrderBy());
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<UserDbContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsersDb;"));

builder.Services.AddScoped<IUser, UserService>();

builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(options =>
{
    options.GeneralRules = new List<RateLimitRule>()
    {
        new RateLimitRule()
        {
            Endpoint = "*",
            Limit = 200,
            Period = "3m"
        }
    };
});
builder.Services.AddInMemoryRateLimiting();

builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseIpRateLimiting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
