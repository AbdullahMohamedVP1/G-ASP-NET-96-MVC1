using Microsoft.AspNetCore.Mvc;
using MVC_A1.Models;

namespace MVC_A1.Controllers
{
    public class ProductsController : Controller
    {
        #region Actions

        //[HttpGet] //By default method GET
        //BaseUrl/Products/Test
        //public string Test()
        //{
        //      return $"Hello from test";
        //}

        // Response
        // [Status code , Content type [default text/palin] , Content ]
        //[HttpGet]
        //public IActionResult Test()
        //{
        //    //ContentResult result = new ContentResult();
        //    //result.ContentType = "text/html";
        //    //result.Content = $"Hello from test </br> Bye";
        //    //result.StatusCode = StatusCodes.Status200OK;
        //    //return result;
        //    if (true)
        //        return Content(content: $"Hello from test </br> Bye", contentType: "text/html");
        //    else
        //        return NotFound();}

        //Master action
        //BaseUrl/Products
        //BaseUrl/Products/Index
        //[HttpGet]
        //public IActionResult Index()
        //{
        // return View();
        //}

        public IActionResult GetProducts()
        {
            var products = new List<Product>() {

            new Product() { Id = 1, Name = "Mobile" },
            new Product() { Id = 2, Name = "Tablet" },

            };

            return Json(products);
        }

        //[NonAction]
        //public IActionResult Test()
        //{
        //    return View();
        //}

        //public IActionResult GetProductById(int id)
        //{
        //    if (id < 0)
        //        return BadRequest();
        //    else if (id == 0)
        //        //return RedirectToAction("GetProducts");
        //        return RedirectToAction(nameof(GetProducts));
        //    else if (id < 10)
        //        return NotFound();
        //    else
        //        return Json(new Product() { Id = id, Name = "Laptop" });
        //}

        //public IActionResult RedirectAction()
        //{
        //    return Redirect("https://docs.google.com/presentation/d/1L5uja6Tj_a38uHlXC-RmNYX1bYfsSqYT/edit?slide=id.p10#slide=id.p10");
        //}

        //public IActionResult FileAction()
        //{

        //    byte[] fileBytes = System.IO.File.ReadAllBytes("wwwroot/files/PdfSample.pdf");
        //    return File(fileBytes, "application/pdf", "Group01.pdf");
        //}
        #endregion
    }
}
