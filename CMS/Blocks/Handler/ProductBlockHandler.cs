using CMS.Blocks.Model;
using CMS.Blocks.ViewModel;
using CMS.Helper;
using MediatR;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using EPiServer.Web;

namespace CMS.Blocks.Handler
{
    public class ProductBlockHandler : IRequestHandler<BlockRequest<ProductBlockModel, ProductBlockViewModel>, ProductBlockViewModel>
    {
        private readonly IUrlResolver _urlresolver;
        public ProductBlockHandler(IUrlResolver urlresolver)
        {
            _urlresolver = urlresolver;
        }
        public async Task<ProductBlockViewModel> Handle(BlockRequest<ProductBlockModel, ProductBlockViewModel> request, CancellationToken cancellationToken)
        {
            var block = request.CurrentBlock;
            if (block == null) return null;

            var model= new ProductBlockViewModel()
            {
                NameLabel = block.NameLabel,
                DescriptionLabel= block.DescriptionLabel,
                AmountLabel = block.AmountLabel,
                QunatityLabel = block.QunatityLabel,
                ApiUrl=_urlresolver.GetUrl(new UrlBuilder(block.APIurl),ContextMode.Default)
            };
            return model;
        }
    }
}
