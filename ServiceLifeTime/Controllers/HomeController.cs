using Microsoft.AspNetCore.Mvc;
using ServiceLifeTime.Models;
using ServiceLifeTime.Services;
using System.Diagnostics;
using System.Text;

namespace ServiceLifeTime.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
       private readonly ISingletoneService singletoneService1;
        private readonly ISingletoneService singletoneService2;
        private readonly IScopedService scopedService1;
        private readonly IScopedService scopedService2;
        private readonly ITransientService transientService1;
        private readonly ITransientService transientService2;

        public HomeController(ISingletoneService singletoneService1, ISingletoneService singletoneService2, IScopedService scopedService1, IScopedService scopedService2, ITransientService transientService1, ITransientService transientService2)
        {
            this.singletoneService1 = singletoneService1;
            this.singletoneService2 = singletoneService2;
            this.scopedService1 = scopedService1;
            this.scopedService2 = scopedService2;
            this.transientService1 = transientService1;
            this.transientService2 = transientService2;
        }

        public string Index()
        {
          StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"SingleTone1 :: {singletoneService1.GetGuid()}");
            stringBuilder.AppendLine($"SingleTone2 :: {singletoneService2.GetGuid()}");
            stringBuilder.AppendLine($"Scoped1 :: {scopedService1.GetGuid()}");
            stringBuilder.AppendLine($"Scoped2 :: {scopedService2.GetGuid()}");
            stringBuilder.AppendLine($"Transient1 :: {transientService1.GetGuid()}");
            stringBuilder.AppendLine($"Transient2 :: {transientService2.GetGuid()}");
             return stringBuilder.ToString();
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
