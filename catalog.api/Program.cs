using catalog.api.Domain;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilita o Swagger em ambientes de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var catalogs = new List<Catalog>
{
    new Catalog{ Id = 1, Name = "Electronics" },
    new Catalog{ Id = 2, Name = "Books" },
    new Catalog{ Id = 3, Name = "Toy & Games" },
    new Catalog{ Id = 4, Name = "Clothing & Accessories" },
    new Catalog{ Id = 5, Name = "Sport Equipments" }
};

app.MapGet("/api/v1/catalogs", () => catalogs)
   .WithName("GetCatalogs")
   .WithTags("Catalogs");

app.MapGet("/api/v1/catalogs/{id:int}", (int id) =>
{
    var catalog = catalogs.FirstOrDefault(c => c.Id == id);
    return catalog is not null ? Results.Ok(catalog) : Results.NotFound();
})
.WithTags("Catalogs");

app.MapDelete("/api/v1/catalogs/{id:int}", (int id) =>
{
    var catalog = catalogs.FirstOrDefault(c => c.Id == id);
    if (catalog is null) return Results.NotFound();

    catalogs.Remove(catalog);
    return Results.NoContent();
})
.WithTags("Catalogs");

app.Run();
