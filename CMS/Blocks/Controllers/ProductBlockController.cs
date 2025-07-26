using CMS.Blocks.Model;
using CMS.Blocks.ViewModel;
using CMS.Helper;
using EPiServer.Web.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Blocks.Controllers
{
    public class ProductBlockController : AsyncBlockComponent<ProductBlockModel>
    {
        private readonly IMediator _mediator;
        public ProductBlockController(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected override async Task<IViewComponentResult> InvokeComponentAsync(ProductBlockModel currentContent)
        {
            var model= new ProductBlockViewModel();
            try
            {
                model = await _mediator.Send(new BlockRequest<ProductBlockModel, ProductBlockViewModel>(currentContent));
            }
            catch (Exception ex) { }

            return View("~/Views/Blocks/ProductBlock/Index.cshtml", model);
        }
    }
}
