using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using WebinarUbuntu.Dto;
using WebinarUbuntu.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebinarDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
        .EnableSensitiveDataLogging(true);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("api/Customers", async (WebinarDbContext context, string? filter) =>
{

    return await context.Set<Customer>()
        .Where(p => p.FirstName.Contains(filter ?? string.Empty) && p.Status)
        .AsNoTracking()
        .ToListAsync();
});

app.MapPost("api/Customers", async (WebinarDbContext context, CustomerDtoRequest request) =>
{

    var entity = new Customer
    {
        FirstName = request.FirstName,
        LastName = request.LastName,
        Age = request.Age
    };

    await context.AddAsync(entity);

    await context.SaveChangesAsync();

    return Results.Ok(new
    {
        Id = entity.Id,
        Success = true
    });

});

app.MapGet("api/Customers/{id:int}", async (WebinarDbContext context, int id) => {

    var entity = await context.Set<Customer>().FindAsync(id);
    if (entity == null)
        return Results.NotFound(id);

    return Results.Ok(entity);
}).Produces<Customer>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapPut("api/Customers/{id:int}", async(WebinarDbContext context, int id, CustomerDtoRequest request) => {

    var entity = await context.Set<Customer>().FindAsync(id);
    if (entity == null)
        return Results.NotFound(id);
    
    entity.FirstName = request.FirstName;
    entity.LastName = request.LastName;
    entity.Age = request.Age;

    await context.SaveChangesAsync();

    return Results.Ok(entity);
});

app.MapDelete("api/Customers/{id:int}", async(WebinarDbContext context, int id) => {

    var entity = await context.Set<Customer>().FindAsync(id);
    if (entity == null)
        return Results.NotFound(id);
    
    entity.Status = false;

    await context.SaveChangesAsync();

    return Results.Ok(entity);
});

app.MapGet("api/Products", async (WebinarDbContext context, string? filter) => {

    var collection = context.Set<Product>()
        .FromSqlRaw("SELECT * FROM Product");

    return await collection.ToListAsync();

});


app.MapPost("api/Sales", async (WebinarDbContext context, SaleDtoRequest request) => {

    var sale = new Sale{
        CustomerId = request.CustomerId,
        SaleDate = DateTime.Today
    };

    var lastNumber = await context.Set<Sale>().AsNoTracking().CountAsync() + 1;
    sale.SaleNumber = $"SALE-{lastNumber:00000}";

    var list = new List<SaleDetail>();

    foreach(var item in request.Details)
    {
        var line = new SaleDetail{
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            TotalPrice = item.Quantity * item.UnitPrice,
            Sale = sale
        };

        list.Add(line);
    }

    sale.TotalSale = list.Sum(p => p.TotalPrice);

    await context.AddAsync(sale);
    await context.AddRangeAsync(list);

    await context.SaveChangesAsync();

    return Results.Ok(new {
        SaleId = sale.Id,
        InvoiceNumber = sale.SaleNumber,
        Success = true
    });
});

app.Run();
