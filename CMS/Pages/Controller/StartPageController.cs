using CMS.Pages.Model;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Pages.Controller
{
    public class StartPageController : PageController<StartPage>
    {
  
        [HttpGet]
        public IActionResult Index()
        {
            //var model = new StartPageViewModel(currentPage);
            return View();
        }
    }
    
}
