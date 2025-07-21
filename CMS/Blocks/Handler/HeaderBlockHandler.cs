using CMS.Blocks.Model;
using CMS.Blocks.ViewModel;
using CMS.Helper;
using MediatR;

namespace CMS.Blocks.Handler
{
    public class HeaderBlockHandler : IRequestHandler<BlockRequest<HeaderBlockModel, HeaderBlockViewModel>, HeaderBlockViewModel>
    {
        private readonly IMediator _mediator;
        private readonly IContentLoader _contentLoader;
        public HeaderBlockHandler(IMediator mediator,IContentLoader contentLoader)
        {
            _mediator = mediator;
            _contentLoader = contentLoader;
        }
        public async Task<HeaderBlockViewModel> Handle(BlockRequest<HeaderBlockModel, HeaderBlockViewModel> request, CancellationToken cancellationToken)
        {
            var block=request.CurrentBlock;
            if (block == null) { return null; }
            var model = new HeaderBlockViewModel()
            {
                Title = block.Title
            };
            if (block.Links != null)
            {
                foreach (var link in block.Links.FilteredItems)
                {
                    if (link != null)
                    {
                        var data = _contentLoader.Get<LinkBlockModel>(link.ContentLink);
                        if (data != null)
                        {
                            var linkData = await _mediator.Send(new BlockRequest<LinkBlockModel, LinkBlockViewModel>(data));
                            if (linkData != null)
                            {
                                model.Links.Add(linkData);
                            }
                        }
                    }
                }
            }
            return model;
        }
    }
}
