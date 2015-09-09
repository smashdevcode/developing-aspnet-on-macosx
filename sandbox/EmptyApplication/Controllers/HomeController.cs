using System;
using Microsoft.AspNet.Mvc;
using EmptyApplication.Data;
using EmptyApplication.Models;

public class HomeController : Controller
{
	private IDataEventRecordResporitory _repository;
	
	public HomeController(IDataEventRecordResporitory repository)
	{
		_repository = repository;
	}	
	
	public IActionResult Index()
	{
		_repository.Post(new DataEventRecord()
		{
			Name = "Test Record",
			Description = "Another test record.",
			Timestamp = DateTime.Now
		});
		
		var data = _repository.GetAll();
		
		ViewBag.Data = data;
		
		return View();
	}

	public string Second()
	{
		return "Hello from Second!";
	}

	//  public IActionResult Second()
	//  {
	//  	return View();
	//  }
}
