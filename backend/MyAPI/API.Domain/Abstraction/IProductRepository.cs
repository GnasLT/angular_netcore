

using API.Domain.Entities;

namespace API.Application.Abstractions
{
    public interface IProductRepository
    {
        public IEnumerable<Products> GetAllProducts();
        public void AddProduct(int id, string name, VPrice price, VStock stock);

        public bool ProductExists(string name);

        public Products GetProductByName(string name);

        public Products GetProductByID(int id);

        public void UpdateProduct(Products product);

        public void IncreaseStock(int id, int newStock);

        public void DecreaseStock(int id, int newStock);

        public void DeleteProduct(int id);


    }
}