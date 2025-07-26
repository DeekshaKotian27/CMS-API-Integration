using System.ComponentModel.DataAnnotations;

namespace CMS.Blocks.Model
{
    [ContentType(DisplayName ="Add Product Block",
        Description ="Block used to display the form to add product",
        GUID = "3b4c0cbd-6945-46f4-9418-1bf148a085d7")]
    public class AddProductBlockModel: BlockData
    {
        [Display(
            Name = "Product name label",
            Description = "Label for product name",
            Order = 10)]
        public virtual string NameLabel { get; set; }

        [Display(
            Name = "Product name Placehoder text",
            Description = "Placehoder text for product name",
            Order = 15)]
        public virtual string NameHelperText { get; set; }

        [Display(
            Name = "Product Description label",
            Description = "Label for product description",
            Order = 20)]
        public virtual string DescriptionLabel { get; set; }

        [Display(
            Name = "Product Description Placehoder text",
            Description = "Placehoder text for product description",
            Order = 25)]
        public virtual string DescriptionHelperText { get; set; }

        [Display(
            Name = "Product Amount label",
            Description = "Label for product amount",
            Order = 30)]
        public virtual string AmountLabel { get; set; }

        [Display(
            Name = "Product Amount Placehoder text",
            Description = "Placehoder text for product amount",
            Order = 35)]
        public virtual string AmountHelperText { get; set; }

        [Display(
            Name = "Product Quantity label",
            Description = "Label for product Quantity",
            Order = 40)]
        public virtual string QunatityLabel { get; set; }

        [Display(
            Name = "Product Quantity Placehoder text",
            Description = "Placehoder text for product Quantity",
            Order = 45)]
        public virtual string QunatityHelperText { get; set; }

        [Display(
            Name = "API URL to create Product",
            Description = "API URL to create Product",
            Order = 50)]
        public virtual Url APIurl { get; set; }

        [Display(
            Name = "Redirect Page URL",
            Description = "Redirect Page URL",
            Order = 50)]
        public virtual Url RedirectPageURL { get; set; }
    }
}
