using System;
using Microsoft.AspNet.Mvc;
using EmptyApplication.Data;
using EmptyApplication.Models;

public class HomeController : Controller
{
	private IRespository _repository;

	public HomeController(IRespository repository)
	{
		_repository = repository;
	}

	public IActionResult Index()
	{
		_repository.Post(new Record()
		{
			Name = "Test Record",
			Description = "Another test record.",
			Timestamp = DateTime.Now
		});

		var data = _repository.GetAll();

		ViewBag.Data = data;

		return View();
	}
}
