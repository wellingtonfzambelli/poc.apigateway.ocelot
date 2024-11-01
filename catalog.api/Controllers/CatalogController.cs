using catalog.api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace catalog.api.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class CatalogController : ControllerBase
{
    private static readonly Catalog[] _catalogs = new Catalog[]
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
}