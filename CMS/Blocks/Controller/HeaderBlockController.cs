using CMS.Blocks.Model;
using CMS.Blocks.ViewModel;
using CMS.Helper;
using EPiServer.Web.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Blocks.Controller
{
    public class HeaderBlockController : AsyncBlockComponent<HeaderBlockModel>
    {
        private readonly IMediator _mediator;
        public HeaderBlockController(IMediator mediator)
        {
            _mediator= mediator;
        }
        protected override async Task<IViewComponentResult> InvokeComponentAsync(HeaderBlockModel currentContent)
        {
            var model= new HeaderBlockViewModel();
            try
            {
                model = await _mediator.Send(new BlockRequest<HeaderBlockModel, HeaderBlockViewModel>(currentContent));
            }
            catch (Exception ex)
            {
            }
             return View("~/Views/Blocks/HeaderBlock/Index.cshtml", model);
        }
    }
}
