using AutoMapper;
using FluentValidator.Web.DTOs;
using FluentValidator.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidator.Web.Controllers
{
	public class ProjectionController(IMapper mapper) : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(EventDateDto eventDateDto)
		{
			EventDate eventDate=mapper.Map<EventDate>(eventDateDto);

			ViewBag.date = eventDate.Date.ToShortDateString();

			return View();
		}
	}
}
