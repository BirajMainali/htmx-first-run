using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Htmx;
using Microsoft.AspNetCore.Mvc;
using htmx_first_run.Models;

namespace htmx_first_run.Controllers;

public class HomeController : Controller
{
    public IActionResult Index(ProductCreateModel vm)
    {
        return Request.IsHtmx() ? PartialView("_IndexPartial", vm) : View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public class ProductCreateModel
{
    [Display(Name = "Product Name")] public string Name { get; set; }

    [Display(Name = "Product Price")] public decimal Price { get; set; }

    [Display(Name = "Description")]
    public string Description { get; set; }
}