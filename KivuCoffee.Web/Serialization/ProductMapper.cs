using KivuCoffee.Data.Models;
using KivuCoffee.Web.ViewModels;

namespace KivuCoffee.Web.Serialization
{
    public class ProductMapper
    {
        /// <summary>
        /// Maps Product model to ProductVM view model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductVM SerializeProductVM(Product product)
        {
            return new ProductVM
            {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsTaxable = product.IsTaxable,
                IsArchive = product.IsArchive
            };
        }

        /// <summary>
        /// Maps ProductVM viewmodel to Product model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Product SerializeProductVM(ProductVM product)
        {
            return new Product
            {
                Id = product.Id,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsTaxable = product.IsTaxable,
                IsArchive = product.IsArchive
            };
        }
    }
}