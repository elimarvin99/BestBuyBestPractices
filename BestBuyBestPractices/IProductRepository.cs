using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyBestPractices
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); //Stubbed out method
        public void CreateProduct(string name, double price, int categoryID);
    }
}
