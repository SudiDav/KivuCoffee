namespace KivuCoffee.Web.ViewModels
{
    public class SalesOrderItemVM
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductVM Product { get; set; }
    }
}