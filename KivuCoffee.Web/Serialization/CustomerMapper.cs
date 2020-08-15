using System;
using KivuCoffee.Data.Models;
using KivuCoffee.Web.ViewModels;

namespace KivuCoffee.Web.Serialization
{
    public static class CustomerMapper
    {
        /// <summary>
        /// Serializes a customer data model into a Customer model ViewModels
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static CustomerVM SerializeCustomer(Customer customer)
        {
            return new CustomerVM
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = MapCustomerAddress(customer.PrimaryAddress)
            };
        }

        /// <summary>
        /// Serializes a CustomerViewModel into a Customer Data model
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static Customer SerializeCustomer(CustomerVM customer)
        {
            return new Customer
            {
                Id = customer.Id,
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = MapCustomerAddress(customer.PrimaryAddress)
            };
        }

        /// <summary>
        /// Maps a CustomerAddress data model to CustomerAddressViewModel
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddressVM MapCustomerAddress(CustomerAddress address)
        {
            return new CustomerAddressVM
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                Street = address.Street,
                City = address.City,
                Country = address.Country,
                Postalcode = address.Postalcode,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Maps a CustomerAddressViewModel to CustomerAddress data model
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static CustomerAddress MapCustomerAddress(CustomerAddressVM address)
        {
            return new CustomerAddress
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                Street = address.Street,
                City = address.City,
                Country = address.Country,
                Postalcode = address.Postalcode,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow
            };
        }
    }
}