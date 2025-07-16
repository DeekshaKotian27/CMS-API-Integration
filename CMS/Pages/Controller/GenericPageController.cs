using CMS.Helper;
using CMS.Pages.Model;
using CMS.Pages.ViewModel;
using EPiServer.Web.Mvc;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Pages.Controller
{
    public class GenericPageController : PageController<GenericPageModel>
    {
        private readonly IMediator _mediator;
        public GenericPageController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ActionResult> Index(GenericPageModel currentPage)
        {
            var model = new GenericPageViewModel();
            try{

                model = await _mediator.Send(new PageRequest<GenericPageModel, GenericPageViewModel>(currentPage));

            }
            catch(Exception e)
            { 

            }

            return View("~/Views/Pages/GenericPage/Index.cshtml", model);
        }
    }
}
