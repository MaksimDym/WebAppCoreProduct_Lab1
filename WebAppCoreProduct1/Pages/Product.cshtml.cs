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

		public Product Product { get; set; }
		public void OnGet()
        {
			MessageRezult = "��� ������ ����� ���������� ������";
		}

		public void OnPost(string name, decimal? price)
		{
			Product = new Product();
			if (price == null || price < 0 || string.IsNullOrEmpty(name))
			{
				MessageRezult = "�������� ������������ ������. ��������� ����";
				return;
			}
			var result = price * (decimal?)0.18;
			MessageRezult = $"��� ������ {name} � ����� {price} ������  ��������� {result}";
			Product.Price = price;
			Product.Name = name;
		
		
		}

        public void OnPostDiscont(string name, decimal? price, double discont)
		{
            Product = new Product();
            var result = price * (decimal?)discont / 100;
            MessageRezult = $"��� ������ {name} � ����� {price} � ������� {discont} ����� ��������� { result}";
            Product.Price = price;
            Product.Name = name;

        }

		public void OnPostTotal(string name, decimal? price, double kol)
		{
			Product = new Product();
			var total = price *(decimal?)kol ;
			MessageRezult = $"{name} � ����� {price} � ����������� {kol} ��������� �� ����� {total}  ������";
			
			Product.Price = price;
			Product.Name = name;     
		    
		}

		private readonly IProductService _productService;

		public ProductModel(IProductService productService)
		{
			_productService = productService;

		}
	
	}
}
