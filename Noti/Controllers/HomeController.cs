using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Noti.Entities;
using Noti.Service.Abstract;
using Noti.Service.Concrete;
using System.Xml.Linq;

namespace Noti.Controllers;

//[Authorize] //Redirect to Login
public class HomeController : Controller
{
    private IService<Post> _service;

    public HomeController(IService<Post> service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("newpost")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<ActionResult> NewPost(string owner, string content)
    {
        await _service.AddAsync(new Post()
        {
            PostOwner = new VirtualProfile()
            {
                DisplayName = owner,
                Name = "Murat"
            },
            PostShareDateTime = DateTime.Now,
            PostContent = content,
            LikeCount = 52
        });
        await _service.SaveAsync();
        return Ok();
    }

    [Route("posts")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public ActionResult Posts()
    {
        var posts = _service.GetAll(include: p => p.PostOwner);
        return Json(posts);
    }

    [Route("homes")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public ActionResult<int> Homes()
    {
        return 1;
    }
}
