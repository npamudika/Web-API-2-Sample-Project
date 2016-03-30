using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductsManagementApp.Models;

namespace ProductsManagementApp
{
	public class ProductRepository : IProductRepository
	{
		private List<Product> products = new List<Product>();
		private int id = 1;

		/// <summary>
		/// Add new Product items
		/// </summary>
		public ProductRepository()
		{
			Add(new Product { Name = "Tomato soup", Category = "Groceries", Price = 1.39M });
			Add(new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75M });
			Add(new Product { Name = "Hammer", Category = "Hardware", Price = 16.99M });
		}

		/// <summary>
		/// Add new Product item
		/// </summary>
		/// <param name="product">{"Name": "Mix Fruit", "Category": "Food Drinks", "Price": 10.99 }</param>
		/// <returns>Newly added Product</returns>
		public Product Add(Product product)
		{
			if (product == null)
			{
				throw new ArgumentNullException("product");
			}
			product.Id = id++;
			products.Add(product);
			return product;
		}

		/// <summary>
		/// Get all products
		/// </summary>
		/// <returns>A list of Products</returns>
		public ICollection<Product> GetAllProducts()
		{
			return products;
		}

		/// <summary>
		/// Get Product by its Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Product corresponding to given Id</returns>
		public Product GetProductById(int id)
		{
			return products.Find(p => p.Id == id);
		}

		/// <summary>
		/// Remove product(s) from the list
		/// </summary>
		/// <param name="id"></param>
		public void Remove(int id)
		{
			products.RemoveAll(p => p.Id == id);
		}

		/// <summary>
		/// Update a given Product
		/// </summary>
		/// <param name="product">{ Name = "Tomato soup", Category = "Groceries", Price = 1.39M }</param>
		/// <returns></returns>
		public bool Update(Product product)
		{
			if (product == null)
			{
				throw new ArgumentNullException("product");
			}
			int index = products.FindIndex(p => p.Id == product.Id);
			if (index == -1)
			{
				return false;
			}
			products.RemoveAt(index);
			products.Add(product);
			return true;
		}
	}
}
