using client.api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace client.api.Controllers;

[ApiController]
[Route("api/v1/clients")]
public sealed class ClientController : ControllerBase
{ 
    private static IList<Client> _clients = new List<Client>
   {
        new Client { Id = 1, Name = "John Smith", Email = "john.smith@gmail.com" },
        new Client { Id = 2, Name = "Alice Johnson", Email = "alice.johnson@example.com" },
        new Client { Id = 3, Name = "Michael Brown", Email = "michael.brown@gmail.com" },
        new Client { Id = 4, Name = "Emily Davis", Email = "emily.davis@yahoo.com" },
        new Client { Id = 5, Name = "James Wilson", Email = "james.wilson@outlook.com" },
        new Client { Id = 6, Name = "Linda Taylor", Email = "linda.taylor@hotmail.com" }
   };

    [HttpGet]
    public async Task<IEnumerable<Client>> GetAsync(CancellationToken ct) =>
        _clients;

    [HttpGet("{id}")]
    public ActionResult<Client> GetById(int id)
    {
        var client = _clients.FirstOrDefault(c => c.Id == id);
        return client != null ? Ok(client) : NotFound();
    }

    [HttpPost]
    public ActionResult<Client> Create(Client client)
    {
        _clients.Add(client);
        return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Client client)
    {
        var clientDB = _clients.FirstOrDefault(s => s.Id == id);
        
        if (clientDB is null) 
            return NotFound();

        clientDB.Name = client.Name;
        clientDB.Email = client.Email;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var client = _clients.FirstOrDefault(c => c.Id == id);
        
        if (client is null) 
            return NotFound();

        _clients.Remove(client);

        return NoContent();
    }
}