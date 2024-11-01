using client.api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace client.api.Controllers;

[ApiController]
[Route("api/clients")]
public class ClientController : ControllerBase
{
    private static readonly Client[] _clients = new Client[]
   {
        new Client{ Id = 1, Name = "John Smith", Email = "john.smith@gmail.com" },
        new Client { Id = 2, Name = "Alice Johnson", Email = "alice.johnson@example.com" },
        new Client { Id = 3, Name = "Michael Brown", Email = "michael.brown@gmail.com" },
        new Client { Id = 4, Name = "Emily Davis", Email = "emily.davis@yahoo.com" },
        new Client { Id = 5, Name = "James Wilson", Email = "james.wilson@outlook.com" },
        new Client { Id = 6, Name = "Linda Taylor", Email = "linda.taylor@hotmail.com" }
   };

    [HttpGet]
    public async Task<IEnumerable<Client>> GetAsync(CancellationToken ct) =>
        _clients;
}