using Gurukul.Infrastructure.Constants;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GurukulCRMProject.Controllers
{
    public class MagazineController : Controller
    {
        private readonly GurukulDbContext _context;
        public MagazineController(GurukulDbContext context)
        {
            _context = context;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Permissions.Magazine.View)]
        public IActionResult Index()
        {
            var magazine = _context.Magazines.Where(x=>!x.IsDelete).ToList();
            return View(magazine);
        }
        [HttpGet]
        [Authorize(Permissions.Magazine.Create)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Magazine model)
        {
            var mag = new Magazine
            {
                Title = model.Title,
                Description = model.Description,
                MagazineType = model.MagazineType,
                Author = model.Author,
                PublisherName = model.PublisherName,
                PublicationDate = model.PublicationDate
            };
            await _context.Magazines.AddAsync(mag);
            await _context.SaveChangesAsync();
            TempData["ResultOk"] = "Record Added Successfully !";
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Permissions.Magazine.Edit)]
        public IActionResult Edit(int id)
        {
            var mag = _context.Magazines.FirstOrDefault(x => x.Id == id);
            if (mag != null)
            {
                var magazine = new Magazine
                {
                    Title = mag.Title,
                    Description = mag.Description,
                    MagazineType = mag.MagazineType,
                    Author = mag.Author,
                    PublisherName = mag.PublisherName,
                    PublicationDate = mag.PublicationDate
                };
                return View(magazine);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Magazine model)
        {
            var mag = await _context.Magazines.FindAsync(model.Id);
            if (mag != null)
            {
                mag.Title = model.Title;
                mag.Description = model.Description;
                mag.MagazineType = model.MagazineType;
                mag.Author = model.Author;
                mag.PublisherName = model.PublisherName;
                mag.PublicationDate = model.PublicationDate;
                await _context.SaveChangesAsync();
                TempData["ResultOk"] = "Record Updated Successfully !";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [Authorize(Permissions.Magazine.Delete)]
        public IActionResult Delete(int id)
        {
            var mag=_context.Magazines.Find(id);
            mag.IsDelete = true;
            _context.SaveChanges();
            TempData["ResultOk"] = "Record Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
