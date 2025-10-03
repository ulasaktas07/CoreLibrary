using Logging.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Logging.Web.Controllers
{
	public class HomeController : Controller
	{
		//private readonly ILogger<HomeController> _logger;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//	_logger = logger;
		//}

		private readonly ILoggerFactory _loggerFactory;

		public HomeController(ILoggerFactory loggerFactory)
		{
			_loggerFactory = loggerFactory;
		}

		public IActionResult Index()
		{
			var _logger = _loggerFactory.CreateLogger("HomeS�n�f�");
			_logger.LogTrace("Index sayfas�na girildi");
			_logger.LogDebug("Index sayfas�na girildi");
			_logger.LogInformation("Index sayfas�na girildi");
			_logger.LogWarning("Index sayfas�na girildi");
			_logger.LogError("Index sayfas�na girildi");
			_logger.LogCritical("Index sayfas�na girildi");
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
