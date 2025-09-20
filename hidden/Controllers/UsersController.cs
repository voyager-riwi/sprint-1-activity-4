using Microsoft.AspNetCore.Mvc;

namespace hidden.Controllers;

public class UsersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Show()
    {
        return View();   
    }
}