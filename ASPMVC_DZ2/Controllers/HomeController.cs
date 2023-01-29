using ASPMVC_DZ2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASPMVC_DZ2.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db = new ApplicationContext();
        public async Task<IActionResult> Index()
        {
            return View("Output", await db.Cities.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ViewModels view)
        {
            db.Areas.Add(view.Areas);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> CreateCity(ViewModels view)
        {
            var at = db.Areas.ToList();
            foreach (Area a in at)
            {
                if(a.Name == view.Cyties.area.Name)
                {
                    db.Cities.Add(view.Cyties);
                    await db.SaveChangesAsync();             
                }
            }
            return RedirectToAction("Index");
        }
    }
}