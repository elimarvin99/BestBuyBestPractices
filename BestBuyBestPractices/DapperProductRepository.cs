using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        //field
        private readonly IDbConnection _connection;
        //Custom Constructor
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;  //when constructed the connection to our database will be created and since it's readonly it can't be changed
        }
        //this way each time we create a repository we create the sql connection that can't be changed
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoryID) " +
                                "VALUES (@name, @price, @categoryID);"
                , new { name = name, price = price, categoryID = categoryID });
        }
        public void UpdateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("UPDATE products (Name, Price, CategoryID) " +
                                "SET (@name = name, @price = price, @categoryID = categoryid)  WHERE PRODUCTS.NAME = NAME;"
                , new { name = name, price = price, categoryID = categoryID });
        }
        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
               new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
               new { productID = productID });
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }
    }
}
