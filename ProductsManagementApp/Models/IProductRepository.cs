using ProductsManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementApp
{
	public interface IProductRepository
	{
		Product Add(Product item);
		ICollection<Product> GetAllProducts();
		Product GetProductById(int id);
		void Remove(int id);
		bool Update(Product item);
	}
}
