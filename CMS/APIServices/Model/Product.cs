namespace CMS.APIServices.Model
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Quantity { get; set; }
        public string ApiURL { get; set; }
        public string RedirectPageURL { get; set; }
    }
}