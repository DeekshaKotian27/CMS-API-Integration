using CMS.Pages.Model;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Pages.Controller
{
    public class HomePageController : PageController<HomePageModel>
    {
        public IActionResult Index(HomePageModel currentPage)
        {
            ViewBag.Title = "Home Page";
            return View("~/Views/Pages/HomePage/Index.cshtml",currentPage);
        }
    }
    
}
