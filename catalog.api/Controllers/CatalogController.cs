using catalog.api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace catalog.api.Controllers;

[ApiController]
[Route("api/v1/catalogs")]
public sealed class CatalogController : ControllerBase
{
    private static IList<Catalog> _catalogs = new List<Catalog>
    {
        new Catalog{ Id = 1, Name = "Electronics" },
        new Catalog{ Id = 2, Name = "Books" },
        new Catalog{ Id = 3, Name = "Toy & Games" },
        new Catalog{ Id = 4, Name = "Clothing & Accessories" },
        new Catalog{ Id = 5, Name = "Sport Equipments" }
    };

    [HttpGet(Name = "GetCatalogs")]
    public async Task<IEnumerable<Catalog>> GetAsync(CancellationToken ct) =>
        _catalogs;

    [HttpGet("{id}")]
    public ActionResult<Catalog> GetById(int id)
    {
        var catalog = _catalogs.FirstOrDefault(c => c.Id == id);
        return catalog != null ? Ok(catalog) : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var catalog = _catalogs.FirstOrDefault(c => c.Id == id);

        if (catalog is null)
            return NotFound();

        _catalogs.Remove(catalog);

        return NoContent();
    }
}