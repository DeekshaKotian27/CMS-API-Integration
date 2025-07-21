using System.ComponentModel.DataAnnotations;

namespace CMS.Blocks.Model
{
    [ContentType(DisplayName = "Header Block",
        Description = "Header for the site",
        GUID = "89b9865a-7e87-46ef-ab80-a91d09123b64")]
    public class HeaderBlockModel:BlockData
    {
        [Display(
            Name ="title",
            Description ="Title for the page" ,
            Order =10
           )]
        public virtual string Title { get; set; }

        [Display(
            Name = "Links",
            Description = "Links",
            Order = 10
           )]
        [AllowedTypes( typeof( LinkBlockModel ) )]
        public virtual ContentArea Links { get; set; }
    }
}
