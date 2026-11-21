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


        [HttpGet] // BASEURL/Products/DownloadFile
        public IActionResult DownloadFile()
        {
            var bytes = System.IO.File.ReadAllBytes("wwwroot/files/notes.pdf");
            return new FileContentResult(bytes, "application/pdf");
        }

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

        [HttpGet] // BASEURL/Products/RedirectToUrl
        public IActionResult RedirectToUrl()
        {
            return Redirect("https://www.google.com");
        }

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

        #region Routing
        // الشكل العام: BaseUrl/Controller/Action/Segment

        // أنواع الـ Segment: Static segment, Variable segment, Mixed segment

        // Static   : BaseUrl/Products/Test/Ten      (كلمة ثابتة)
        // Variable : BaseUrl/Products/Test/{Num}    (قيمة بتتغير)
        // Mixed    : BaseUrl/Products/Test/x{Num}   (جزء ثابت + جزء بيتغير)


        // الـ Param ممكن يجي من: Segment أو Query param

        // BaseUrl/Products/Test?num=10


        // BaseUrl/Products/Test01
        // [HttpGet("Products/Test01")]
        // public IActionResult TestRouting()
        // {
        //     return Json("Hello from testrouting");
        // }


        // BaseUrl/TestingRoute/Test10
        // [HttpGet("TestingRoute/Test{id:int}")]
        // public IActionResult TestRouting(int id)
        // {
        //     return Json($"Hello with id : {id}");
        // }


        // BaseUrl/Products/TestRouting/10?name=Mariam
        // الـ id جاي من الـ Segment، والـ name جاي من الـ Query string
        public IActionResult TestRouting(int id, string name)
        {
            return Json($"Hello from TestRouting : id -> {id}, name -> {name}");
        }
        #endregion

        #region Model Binding
        // الـ Action ممكن تاخد Params من نوع:
        // Simple data, Complex data (كلاس من عندنا), Collection

        // BaseUrl/Products/GetById?id=1&id2=2

        // Simple data
        [HttpGet]
        public IActionResult GetById(
            [FromQuery] int id,
            [FromQuery(Name = "id2")] int anotherId)   // الاسم في اللينك id2 والمتغير اسمه anotherId
        {
            return Json(new { id, anotherId });
        }

        // Complex data
        // بتيجي من الـ Query string، وأسماء الـ properties بتتكتب مباشرة
        // (أو بشكل: اسم الـ param.اسم الـ property)
        public IActionResult Search(ProductFilter filter)
        {
            return Content("Search completed");
        }

        // Collection
        // BaseUrl/Products/GetByIds?ids=1&ids=2&ids=3
        [HttpGet]
        public IActionResult GetByIds(int[] ids)
        {
            return Json(new { ids });
        }
        #endregion


    }
}
