using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class CategoriesController : Controller
  {
    [HttpGet("/Categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    [HttpGet("/Categories/CreateForm")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/Categories")]
    public ActionResult AddCategory(string newcategory)
    {
      Category newCat = new Category(newcategory);
      newCat.Save();
      return View("Index", Category.GetAll());
    }

    [HttpGet("/Categories/Delete")]
    public ActionResult DeleteAll()
    {
      Category.DeleteAll();
      return View("Index", Category.GetAll());
    }

    [HttpGet("/Categories/{id}/delete")]
    public ActionResult DeleteCatagory(int id)
    {
      Category toBeDeleted = Category.Find(id);
      toBeDeleted.DeleteCatagory();
      return View("Index", Category.GetAll());
    }
  }
}
