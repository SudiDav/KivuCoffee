using System;

namespace KivuCoffee.Web.ViewModels
{
    public class CustomerAddressVM
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Postalcode { get; set; }
        public string Country { get; set; }
    }
}