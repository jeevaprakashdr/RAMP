using System.Reflection;
using API.Clients;
using API.Db;
using API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "RAMP API",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<ApiDatabaseContext>(optionsBuilder =>
    optionsBuilder.UseInMemoryDatabase("RampDatabase"));

builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ITestNetClient, TestNetClient>();
    
var app = builder.Build();
SeedRampOrdersData(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedRampOrdersData(IHost app)
{
    var scope = app.Services.CreateScope();
    var database = scope.ServiceProvider.GetService<ApiDatabaseContext>();
    var random = new Random();
    
    for (var i = 0; i < 10; i++)
    {
        var order = new Order
        {
            WalletAddress = RandomString(20),
            Status = random.Next(2) == 0,
            Unit = RandomDecimal(),
            Created = DateTime.Now.AddDays(random.Next(1, 10) * -1).AddHours(random.Next(1, 24) * -1)
        };
        database.Orders.Add(order);
    }

    database.SaveChanges();
}

string RandomString(int length)
{
    var random = new Random();
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    return new string(Enumerable.Repeat(chars, length)
        .Select(s => s[random.Next(s.Length)]).ToArray());
}

decimal RandomDecimal()
{
    var random = new Random();
    return new decimal(random.NextDouble() * random.Next(1, 20));
}