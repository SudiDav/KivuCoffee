using System;
using System.ComponentModel.DataAnnotations;

namespace KivuCoffee.Web.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        [MaxLength(32)]
        public string FirstName { get; set; }

        [MaxLength(32)]
        public string LastName { get; set; }

        public CustomerAddressVM PrimaryAddress { get; set; }
    }
}