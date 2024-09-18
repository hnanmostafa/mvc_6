using Microsoft.AspNetCore.Mvc;

namespace Session_2.Controllers
{
    public class ProductsController : Controller
    {
        //Model Binding
        //1-from Form
        //2-From Rout
        //3-Query String
        //4-from Body
        //5-from Header

        //Action =>public nostatic Method
        public IActionResult Get(int id, string name, Product product)
        {
           // ContentResult contentResult = new ContentResult();
           // contentResult.Content = $"Products {id}";
            //contentResult.ContentType = "object/pdf";
           
            return Content($"Products {id} : {name}");
        }
        public IActionResult Redirectt()
        {
            //RedirectResult redirectResult= new RedirectResult("https://www.google.com");
       
        return Redirect("https://www.google.com");
        
        }

        public IActionResult RedirectToAction()
        {
            RedirectToActionResult redirectResult = new RedirectToActionResult("Get","Products", new {id=10});

            return redirectResult;

        }
    }
}
