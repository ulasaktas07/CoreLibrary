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
			var _logger = _loggerFactory.CreateLogger("HomeSýnýfý");
			_logger.LogTrace("Index sayfasýna girildi");
			_logger.LogDebug("Index sayfasýna girildi");
			_logger.LogInformation("Index sayfasýna girildi");
			_logger.LogWarning("Index sayfasýna girildi");
			_logger.LogError("Index sayfasýna girildi");
			_logger.LogCritical("Index sayfasýna girildi");
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
