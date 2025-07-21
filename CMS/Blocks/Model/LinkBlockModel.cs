using System.ComponentModel.DataAnnotations;

namespace CMS.Blocks.Model
{
    [ContentType(DisplayName ="Link Block",
        Description ="Block to display link",
        GUID = "c92ea984-8f91-4945-9cd5-d07c2877e38d")]
    public class LinkBlockModel:BlockData
    {
        [Display(
            Name = "Title",
            Description = "Title for the Link",
            Order = 10)]
        public virtual string Title { get; set; }

        [Display(
            Name = "Link url",
            Description = "Link url",
            Order = 10)]
        public virtual Url LinkURL { get; set; }
    }
}
