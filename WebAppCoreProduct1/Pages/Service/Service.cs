using WebAppCoreProduct1.Models;

namespace WebAppCoreProduct1.Pages.Service
{
	public interface IProductService // создание интерфейса
	{

		void AddProduct(Product product);



	}

	public class ProductService : IProductService
	{

		public void AddProduct(Product product) 
		{
		 
		}

	}
}

