using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using Udemy.EfCore.Models;
using UdemyEfCore.Data.Contexts;
using UdemyEfCore.Data.Entities;


namespace Udemy.EfCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            UdemyContext context = new();

            //var entityEntry = context.Products.Add(new Product
            //{
            //    Name = "Telefon",
            //    Price = 0606
            //});
            //context.SaveChanges();


            //var updatedProduct = context.Products.Find(3);//id değeri 2 olanın güncelleştirme işlemini yapıyoruz 
            //updatedProduct.Price = 4000;//fiyatını 4000 tl yaptık 
            //context.Products.Update(updatedProduct);// Products'ın ürün bilgisi değişti

            //context.SaveChanges();// Yapılan değişiklikleri kaydettik.

            //var deletedProduct = context.Products.FirstOrDefault(x => x.Id == 2);
            //context.Products.Remove(deletedProduct);
            //context.SaveChanges();


            //Product product = new() { Price = 4000 };
            //context.Products.Add(product);
            //context.SaveChanges();

            //Product product = new() { Price = 4000 };
            //context.Products.Add(product);
            //context.SaveChanges();

            context.Employees.Add(new PartTimeEmployee
            {
                DailyWage = 400,
                FirstName = "part",
                LastName = "part",
            });

            context.Employees.Add(new PartTimeEmployee
            {
                DailyWage = 400,
                FirstName = "part2",
                LastName = "part2",
            });

            context.Employees.Add(new FullTimeEmployee
            {
                HourlyWage = 60,
                FirstName = "full",
                LastName = "full"
            });

            context.SaveChanges(); // Yeni kayıtları veritabanına kaydet

            //var parts = context.PartTimeEmployees.ToList();
            //var parts2 = context.Employees.Where(x => x is PartTimeEmployee).ToList();


            return View();
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
}

