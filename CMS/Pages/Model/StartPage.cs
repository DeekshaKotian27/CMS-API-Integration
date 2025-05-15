using System.ComponentModel.DataAnnotations;

namespace CMS.Pages.Model
{
    [ContentType(DisplayName = "Start Page", 
        Description = "The start page of the site.",
        GUID = "733bd3a6-f7b3-456e-aa40-75b74e484c7e")]
    public class StartPage: PageData
    {
        [Display(
            Name = "Main Content Area", 
            Description = "The main body of the start page.",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual ContentArea Main { get; set; }
        
    }
}
