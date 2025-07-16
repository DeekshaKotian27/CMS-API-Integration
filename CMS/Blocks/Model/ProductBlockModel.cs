using System.ComponentModel.DataAnnotations;

namespace CMS.Blocks.Model
{
    [ContentType(
        DisplayName ="Product Block",
        Description ="Block for products",
        GUID = "0c7b3356-c891-401d-a7c2-1f0faf6a7d8b")]
    public class ProductBlockModel: BlockData
    {
        [Display(
            Name ="Product name label",
            Description ="Label for product name",
            Order =10)]
        public virtual string NameLabel { get; set; }

        [Display(
            Name = "Product Description label",
            Description = "Label for product description",
            Order = 20)]
        public virtual string DescriptionLabel { get; set; }

        [Display(
            Name = "Product Amount label",
            Description = "Label for product amount",
            Order = 30)]
        public virtual string AmountLabel { get; set; }

        [Display(
            Name = "Product Quantity label",
            Description = "Label for product Quantity",
            Order = 40)]
        public virtual string QunatityLabel { get; set; }

        [Display(
            Name = "API URL to fetch data",
            Description = "API URL to fetch product data",
            Order = 50)]
        public virtual Url APIurl { get; set; }

    }
}
