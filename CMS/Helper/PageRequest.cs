using MediatR;

namespace CMS.Helper
{
    public class PageRequest<TModel, TViewModel> : IRequest<TViewModel> where TModel : PageData where TViewModel : BasePageViewModel
    {
        public TModel CurrentPage { get; set; }
        public PageRequest(TModel currentPage)
        {
            CurrentPage = currentPage;
        }
    }


}
