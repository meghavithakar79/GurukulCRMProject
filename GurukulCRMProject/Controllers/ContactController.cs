using Gurukul.Infrastructure.Constants;
using Gurukul.Infrastructure.Filters;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GurukulCRMProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly GurukulDbContext _context;
        private readonly IAuthorizationService _service;
        public ContactController(GurukulDbContext context, IAuthorizationService service)
        {
            _context = context;
            _service = service;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize(Permissions.Contact.View)]
        public IActionResult Index()
        {
            var contact = _context.Contacts.Where(x => !x.IsDelete).ToList();
            return View(contact);
        }
        [Authorize(Permissions.Contact.Create)]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contact model)
        {
            var con = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                Email = model.Email,
                Gender = model.Gender,
                BloodGroup = model.BloodGroup,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                OccupationType = model.OccupationType,
                Occupation = model.Occupation,
                EducationLevel = model.EducationLevel
            };
            await _context.Contacts.AddAsync(con);
            await _context.SaveChangesAsync();
            TempData["ResultOk"] = "Record Added Successfully !";
            return RedirectToAction("Index");

        }
        [Authorize(Permissions.Contact.Edit)]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var con = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
            if (con != null)
            {
                var viewModel = new Contact()
                {
                    FirstName = con.FirstName,
                    LastName = con.LastName,
                    DOB = con.DOB,
                    Email = con.Email,
                    Gender = con.Gender,
                    BloodGroup = con.BloodGroup,
                    PhoneNumber = con.PhoneNumber,
                    Address = con.Address,
                    City = con.City,
                    State = con.State,
                    ZipCode = con.ZipCode,
                    OccupationType = con.OccupationType,
                    Occupation = con.Occupation,
                    EducationLevel = con.EducationLevel
                };
                string selectedGender = con.Gender;
                string selectedOccupationType = con.OccupationType;
                ViewBag.SelectedGender = selectedGender;
                ViewBag.OccupationType = selectedOccupationType;
                return View(viewModel);
            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Contact model)
        {
            var con = await _context.Contacts.FindAsync(model.Id);
            if (con != null)
            {
                con.FirstName = model.FirstName;
                con.LastName = model.LastName;
                con.DOB = model.DOB;
                con.Email = model.Email;
                con.Gender = model.Gender;
                con.BloodGroup = model.BloodGroup;
                con.PhoneNumber = model.PhoneNumber;
                con.Address = model.Address;
                con.City = model.City;
                con.State = model.State;
                con.ZipCode = model.ZipCode;
                con.OccupationType = model.OccupationType;
                con.Occupation = model.Occupation;
                con.EducationLevel = con.EducationLevel;
                await _context.SaveChangesAsync();
                TempData["ResultOk"] = "Record Updated Successfully !";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [Authorize(Permissions.Contact.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var con = await _context.Contacts.FindAsync(id);
            con.IsDelete = true;
            await _context.SaveChangesAsync();
            TempData["ResultOk"] = "Record Deleted Successfully !";
            return RedirectToAction("Index");

        }
       /* public IActionResult NotFound()
        {
            return View();
        }*/
    }
}