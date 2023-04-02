using Microsoft.AspNetCore.Mvc;

namespace Noti.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new Entity.VirtualProfile()
        {
            DisplayName = "Groophy",
            Name = "Murat"
        });
    }
}
