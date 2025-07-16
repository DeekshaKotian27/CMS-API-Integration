using MediatR;

namespace CMS.Helper
{
    public class BlockRequest<TModel, TViewModel> : IRequest<TViewModel>
        where TModel : BlockData
        where TViewModel : BaseBlockViewModel
    {
        public TModel CurrentBlock { get; set; }
        public BlockRequest(TModel currentBlock)
        {
            CurrentBlock = currentBlock;
        }
    }


}
 