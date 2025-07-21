using CMS.Blocks.Model;
using CMS.Blocks.ViewModel;
using CMS.Helper;
using EPiServer.Web;
using EPiServer.Web.Routing;
using MediatR;

namespace CMS.Blocks.Handler
{
    public class LinkBlockHandler : IRequestHandler<BlockRequest<LinkBlockModel, LinkBlockViewModel>,LinkBlockViewModel>
    {
        private readonly IUrlResolver _urlresolver;
        public LinkBlockHandler(IUrlResolver urlresolver)
        {
            _urlresolver = urlresolver;
        }

        public async Task<LinkBlockViewModel> Handle(BlockRequest<LinkBlockModel, LinkBlockViewModel> request, CancellationToken cancellationToken)
        {
            var block=request.CurrentBlock;
            if (block == null) return null;
            
            var model= new LinkBlockViewModel()
            {
                Title=block.Title,
                URL=_urlresolver.GetUrl(new UrlBuilder(block.LinkURL), ContextMode.Default)
            };
            return model;
        }
    }
}
