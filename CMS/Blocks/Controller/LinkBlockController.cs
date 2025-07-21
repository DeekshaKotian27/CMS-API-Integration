using CMS.Blocks.Model;
using CMS.Blocks.ViewModel;
using CMS.Helper;
using EPiServer.Web.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Blocks.Controller
{
    public class LinkBlockController : AsyncBlockComponent<LinkBlockModel>
    {
        private readonly IMediator _mediator;
        public LinkBlockController(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected async override Task<IViewComponentResult> InvokeComponentAsync(LinkBlockModel currentContent)
        {
            var model= new LinkBlockViewModel();
            try
            {
                model = await _mediator.Send(new BlockRequest<LinkBlockModel, LinkBlockViewModel>(currentContent));
            }
            catch { }

            return View("~/Views/Block/LinkBlock/Index.cshtml",model);
        }
    }
}
