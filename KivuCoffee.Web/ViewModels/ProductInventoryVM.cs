namespace KivuCoffee.Web.ViewModels
{
    public class ProductInventoryVM
    {
        public int Id { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
        public ProductVM Product { get; set; }
    }
}