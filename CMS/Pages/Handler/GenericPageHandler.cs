using CMS.Helper;
using CMS.Pages.Model;
using CMS.Pages.ViewModel;
using MediatR;

namespace CMS.Pages.Handler
{
    public class GenericPageHandler : IRequestHandler<PageRequest<GenericPageModel,GenericPageViewModel>, GenericPageViewModel>
    {
        public async Task<GenericPageViewModel> Handle(PageRequest<GenericPageModel,GenericPageViewModel> request, CancellationToken cancellationToken)
        {
            var page = request.CurrentPage;
            if (page == null)
            {
                return null;
            }
            return new GenericPageViewModel()
            {
                Main = page.MainRegion
            };
        }
    }
}
 