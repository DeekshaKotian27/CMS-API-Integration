using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CMS.Pages.Model
{
    [ContentType(DisplayName ="Generic Page",
        Description ="Base page",
        GUID = "b4092cb7-cb16-4e3f-9021-43009a591962")]
    public class GenericPageModel:PageData,IRequest
    {
        [Display(
            Name ="Main Region",
            Description ="Main Region",
            Order =10)]
        public virtual ContentArea MainRegion { get; set; }
    }
}
