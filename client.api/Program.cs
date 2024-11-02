using client.api.Domain;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços necessários para o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o Swagger para o ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Dados iniciais de clientes
var clients = new List<Client>
{
    new Client { Id = 1, Name = "John Smith", Email = "john.smith@gmail.com" },
    new Client { Id = 2, Name = "Alice Johnson", Email = "alice.johnson@example.com" },
    new Client { Id = 3, Name = "Michael Brown", Email = "michael.brown@gmail.com" },
    new Client { Id = 4, Name = "Emily Davis", Email = "emily.davis@yahoo.com" },
    new Client { Id = 5, Name = "James Wilson", Email = "james.wilson@outlook.com" },
    new Client { Id = 6, Name = "Linda Taylor", Email = "linda.taylor@hotmail.com" }
};

// Definindo as rotas para o CRUD de clientes
app.MapGet("/api/v1/clients", () => clients)
   .WithName("GetClients")
   .WithTags("Clients");

app.MapGet("/api/v1/clients/{id:int}", (int id) =>
{
    var client = clients.FirstOrDefault(c => c.Id == id);
    return client is not null ? Results.Ok(client) : Results.NotFound();
})
.WithName("GetClientById")
.WithTags("Clients");

app.MapPost("/api/v1/clients", (Client client) =>
{
    clients.Add(client);
    return Results.Created($"/api/v1/clients/{client.Id}", client);
})
.WithName("CreateClient")
.WithTags("Clients");

app.MapPut("/api/v1/clients/{id:int}", (int id, Client updatedClient) =>
{
    var client = clients.FirstOrDefault(c => c.Id == id);
    if (client is null) return Results.NotFound();

    client.Name = updatedClient.Name;
    client.Email = updatedClient.Email;

    return Results.NoContent();
})
.WithName("UpdateClient")
.WithTags("Clients");

app.MapDelete("/api/v1/clients/{id:int}", (int id) =>
{
    var client = clients.FirstOrDefault(c => c.Id == id);
    if (client is null) return Results.NotFound();

    clients.Remove(client);
    return Results.NoContent();
})
.WithName("DeleteClient")
.WithTags("Clients");

app.Run();
