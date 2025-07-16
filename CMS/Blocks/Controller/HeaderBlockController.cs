using CMS.Blocks.Model;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Blocks.Controller
{
    public class HeaderBlockController : AsyncBlockComponent<HeaderBlockModel>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(HeaderBlockModel currentContent)
        {
             return View("~/Views/Blocks/HeaderBlock/Index.cshtml", currentContent);
        }
    }
}
