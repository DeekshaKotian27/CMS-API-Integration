using CMS.Blocks.Model;
using CMS.Blocks.ViewModel;
using CMS.Helper;
using EPiServer.Web;
using EPiServer.Web.Routing;
using MediatR;

namespace CMS.Blocks.Handler
{
    public class AddProductBlockHandler : IRequestHandler<BlockRequest<AddProductBlockModel, AddProductBlockViewModel>, AddProductBlockViewModel>
    {
        private readonly IUrlResolver _urlresolver;
        public AddProductBlockHandler(IUrlResolver urlresolver)
        {
            _urlresolver = urlresolver;
        }
        public async Task<AddProductBlockViewModel> Handle(BlockRequest<AddProductBlockModel, AddProductBlockViewModel> request, CancellationToken cancellationToken)
        {
            var block=request.CurrentBlock;
            if (block == null) { return null; }

            var model = new AddProductBlockViewModel();
            
            model.NameLabel = block.NameLabel;
            model.NamePlacehoderText = block.NameHelperText;
            model.DescriptionLabel = block.DescriptionLabel;
            model.DescriptionPlacehoderText = block.DescriptionHelperText;
            model.AmountLabel = block.AmountLabel;
            model.AmountPlacehoderText = block.AmountHelperText;
            model.QunatityLabel = block.QunatityLabel;
            model.QunatityPlacehoderTextl = block.QunatityHelperText;
            if (block.APIurl != null)
            {
                model.ApiUrl = _urlresolver.GetUrl(new UrlBuilder(block.APIurl), ContextMode.Default);
            }
            if (block.RedirectPageURL != null)
            {
                model.RedirectPageURL = _urlresolver.GetUrl(new UrlBuilder(block.RedirectPageURL), ContextMode.Default);
            }
            return model;
        }
    }
}
