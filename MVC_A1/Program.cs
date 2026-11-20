using Microsoft.AspNetCore.Mvc;

namespace MVC_A1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // أي Request جاي HTTP بيتحول تلقائي لـ HTTPS
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets(); // بيخلي التطبيق يقدّم الملفات الثابتة (CSS / JS / Images) من فولدر wwwroot
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run(); // بنشغّل التطبيق ويفضل شغال مستني الـ Requests

            #region What is MVC?
            // MVC اختصار لـ Model - View - Controller
            // فكرته إننا نقسّم التطبيق لـ 3 أجزاء، وكل جزء ليه شغلة:
            //   Model      : بيجيب الداتا (هنا المنتجات)
            //   View       : بيعرض الداتا للمستخدم كـ HTML (Index.cshtml)
            //   Controller : بيستقبل الـ Request وبينسّق بين الـ Model والـ View
            #endregion

            #region How a request flows in MVC

            // 1 Browser
            // المتصفح بيبعت Request:
            // GET /Products


            // 2 Routing
            // الـ Routing بيقرا اللينك ويعرف الـ Action المطلوب
            // /Products  =>  ProductsController  +  Index()
            // (ده شغل الـ MapControllerRoute اللي في Program.cs)

            // 3 Controller
            // public class ProductsController : Controller
            // {
            //public IActionResult Index()
            //{// الـ Controller بيطلب الداتا من الـ Model
            //    var products = Product.GetAll();

            //    // وبعدها بيبعتها للـ View عشان تتعرض
            //    return View(products);
            //     }
            //}

            // 4 Model
            //public class Product
            //{
            //    public int Id { get; set; }
            //    public string Name { get; set; }

            //    // بيجيب المنتجات (هنا ليست بسيطة بدل داتابيز)
            //    public static List<Product> GetAll()
            //    {
            //        return new List<Product>
            //{
            //    new Product { Id = 1, Name = "Laptop" },
            //    new Product { Id = 2, Name = "Mouse" }
            //};
            //    }
            //}

            // 5 View  (Views/Products/Index.cshtml)
            /*
            @model List<Product>

            @foreach (var item in Model)
            {
                <p>@item.Name</p>
            }
            */
            // الـ View بتاخد الداتا وتحوّلها لـ HTML

            // 6 HTML back to browser
            // الـ HTML الناتج بيرجع للمتصفح والمستخدم يشوف الصفحة

            #endregion

            #region Project Structure & Conventions

            /*
            Route.MvcSession01/
            ├── Controllers/
            │   └── ProductsController.cs
            ├── Models/
            │   └── Product.cs
            ├── Views/
            │   ├── Products/
            │   │   └── Index.cshtml
            │   └── Shared/
            │       └── _Layout.cshtml
            ├── wwwroot/
            └── Program.cs
            */

            #region Controllers
            // فولدر الـ Controllers: فيه الكلاسات اللي بتستقبل الـ Requests
            // مثال: ProductsController.cs
            #endregion

            #region Models
            // فولدر الـ Models: فيه الكلاسات اللي بتمثّل الداتا
            // مثال: Product.cs
            #endregion

            #region Views
            // فولدر الـ Views: فيه صفحات الـ HTML اللي بتتعرض للمستخدم

            // Views/Products/Index.cshtml
            // فولدر لكل Controller (Products) وجواه الـ View الخاصة بالـ Action (Index)

            // Views/Shared/_Layout.cshtml
            // فولدر الـ Shared فيه الحاجات المشتركة بين كل الصفحات
            // زي الـ _Layout اللي هو الشكل العام للصفحة
            #endregion

            #region wwwroot
            // فولدر الملفات الثابتة (Static Files): الـ css والـ js والـ images
            #endregion

            #region Program.cs
            // ملف البداية للتطبيق: فيه الـ Services والـ Pipeline
            #endregion

            #endregion
        }
    }
}
