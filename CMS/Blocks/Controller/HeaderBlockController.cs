using CMS.Blocks.Model;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Blocks.Controller
{
    public class HeaderBlockController : AsyncBlockComponent<HeaderBlock>
    {
        protected override async Task<IViewComponentResult> InvokeComponentAsync(HeaderBlock currentContent)
        {
             return View("~/Views/Blocks/HeaderBlock/Index.cshtml", currentContent);
        }
    }
}
