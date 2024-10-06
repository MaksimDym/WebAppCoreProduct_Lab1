using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using WebAppCoreProduct1.Models;
using WebAppCoreProduct1.Pages.Service;



namespace WebAppCoreProduct1.Pages
{
    public class ProductModel : PageModel
    {
		public string? MessageRezult { get; private set; }

		public Product Product { get; set; } = new Product();

		public decimal Total { get; set; } 

		public IProductService Get_productService()
		{
			return _productService;
		}

		public void OnGet(double p1)
        {
			

		}

		
		public void OnPost(string name, decimal? price)
		{
			Product = new Product();
			if (price == null || price < 0 || string.IsNullOrEmpty(name))
			{
				MessageRezult = "Переданы некорректные данные. Повторите ввод";
				return;
			}
			var result = price * (decimal?)0.18;
			MessageRezult = $"Для товара {name} с ценой {price} скидка  получится {result}";
			Product.Price = price;
			Product.Name = name;
		
		
		}

        public void OnPostDiscont(string name, decimal? price, double discont)
		{
            Product = new Product();
            var result = price * (decimal?)discont / 100;
            MessageRezult = $"Для товара {name} с ценой {price} и скидкой {discont} сумма получится { result}";
            Product.Price = price;
            Product.Name = name;

        }

		public void OnPostTotal(string name, decimal? price, double kol)
		{
			Product = new Product();
			var total = price *(decimal?)kol ;
			MessageRezult = $"{name} с ценой {price} и количеством {kol} получится на сумму {total}  рублей";
			
			Product.Price = price;
			Product.Name = name;
			_productService.AddProduct(Product);
			MessageRezult += "   Продукт успешно добавлен через службу productService.";


		}

		private readonly IProductService _productService;

		public ProductModel(IProductService productService)
		{
			_productService = productService;

		}

		

		



	}
}
