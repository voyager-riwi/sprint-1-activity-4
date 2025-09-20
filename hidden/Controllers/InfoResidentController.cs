using Microsoft.AspNetCore.Mvc;

namespace hidden.Controllers;

public class InfoResidentController : Controller
{
    public IActionResult Show()
    {
        return View();
    }
}