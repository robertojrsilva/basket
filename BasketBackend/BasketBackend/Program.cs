using BasketBackend.Services.Basket;
using BasketBackend.Services.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var xmlDoc = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, "xml");
builder.Services.AddSwaggerGen(options => options.IncludeXmlComments(xmlDoc, true));

builder.Services.AddSingleton<ProductService>();
builder.Services.AddSingleton<ReceiptService>();

builder.Services.AddSingleton<ICheckoutService, CheckoutService>();

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
