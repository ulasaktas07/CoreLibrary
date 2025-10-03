using ErrorHandling.Filter;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Controllers
{

	public class ProductController : Controller
	{
		public IActionResult Index()
		{
			throw new Exception("veri tabanında  bir hata meydana geldi");
			return View();
		}
	
	}
}
