using Microsoft.AspNetCore.Mvc;

namespace hidden.Controllers;

public class InfoContactController : Controller
{
    public IActionResult Show()
    {
        return View();
    }
}