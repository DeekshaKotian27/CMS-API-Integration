using CMS.Helper;

namespace CMS.Blocks.ViewModel
{
    public class HeaderBlockViewModel:BaseBlockViewModel
    {
        public string Title {  get; set; }
        public List<LinkBlockViewModel> Links { get; set; } = new List<LinkBlockViewModel>();
    }
}
