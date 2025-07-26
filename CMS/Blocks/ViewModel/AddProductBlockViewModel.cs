using CMS.Helper;

namespace CMS.Blocks.ViewModel
{
    public class AddProductBlockViewModel:BaseBlockViewModel
    {
        public string NameLabel { get; set; }
        public string DescriptionLabel { get; set; }
        public string AmountLabel { get; set; }
        public string QunatityLabel { get; set; }
        public string NamePlacehoderText { get; set; }
        public string DescriptionPlacehoderText { get; set; }
        public string AmountPlacehoderText { get; set; }
        public string QunatityPlacehoderTextl { get; set; }
        public string ApiUrl { get; set; }
        public string RedirectPageURL { get; set; }
    }
}
