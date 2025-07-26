using CMS.APIServices;
using CMS.APIServices.Model;
using CMS.Blocks.Model;
using CMS.Blocks.ViewModel;
using CMS.Helper;
using EPiServer.Web.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace CMS.Blocks.Controllers
{
    public class AddProductBlockController : AsyncBlockComponent<AddProductBlockModel>
    {
        private readonly IMediator _mediator;
        private readonly IAPIBaseService _apiService;
        public AddProductBlockController(IMediator mediator, IAPIBaseService aPIBaseService)
        {
            _mediator = mediator;
            _apiService = aPIBaseService;
        }
        protected override async Task<IViewComponentResult> InvokeComponentAsync(AddProductBlockModel currentContent)
        {
            var model=new AddProductBlockViewModel();
            try
            {
                model = await _mediator.Send(new BlockRequest<AddProductBlockModel, AddProductBlockViewModel>(currentContent));

            }
            catch (Exception ex)
            {
            }
            return View("~/Views/Blocks/AddProductBlock/Index.cshtml", model);
        }

    }
}
