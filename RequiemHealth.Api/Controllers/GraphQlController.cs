using Microsoft.AspNetCore.Mvc;
using RequiemHealth.Utilities;


namespace RequiemHealth.Api.Controllers;

/*[Route("[controller]")]
public class GraphQlController : Controller
{
    public GraphQlController()
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var inputs = query.Variables?.ToInputs();
    }
}*/