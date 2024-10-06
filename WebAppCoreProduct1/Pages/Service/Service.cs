namespace WebAppCoreProduct1.Pages.Service
{
	public interface IProductService // создание интерфейса
	{
		string GetData();
	}

	public class ProductService : IProductService
	{
		public string GetData()
		{
			return "Метод вызван";
		}

	}
}

