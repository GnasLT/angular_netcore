using API.Application.Abstractions;
using API.Domain.Entities;

namespace API.Infrastructure.Persistence
{
    public class ProductRepository : IProductRepository
    {

        private List<Products> products;

        public ProductRepository()
        {
            products = new List<Products>()
            {
                new Products(1,"Iphone 14", new VPrice(20000,"VND"), new VStock(100)),
                new Products(2,"Samsung S23", new VPrice(10000,"VND"), new VStock(150)),
                new Products(3,"Xiaomi 13", new VPrice(1200,"VND"), new VStock(200)),
                new Products(4,"Nokia 3310", new VPrice(5000,"VND"), new VStock(300))
            };
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return products;
        }

        public void AddProduct(string name, VPrice price, VStock stock)
        {
            throw new NotImplementedException();
        }

        public void DecreaseStock(int id, int newStock)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(string name)
        {
            throw new NotImplementedException();
        }

        public Products GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public Products GetProductByID(int id)
        {
            foreach (var product in this.products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }

        public bool ProductExists(string name)
        {
            throw new NotImplementedException();
        }

        public void IncreaseStock(int id, int newStock)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Products product)
        {
            throw new NotImplementedException();
        }
    }

}