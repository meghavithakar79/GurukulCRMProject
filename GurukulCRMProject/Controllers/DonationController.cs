using Gurukul.Infrastructure.Constants;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GurukulCRMProject.Controllers
{
    public class DonationController : Controller
    {
        private readonly GurukulDbContext _context;
        public DonationController(GurukulDbContext context)
        {
            _context = context;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       [Authorize(Permissions.Donation.View)]
        public IActionResult Index()
        {
            var donations = _context.Donations.Where(x => !x.IsDeleted).ToList();
            return View(donations);
        }
       [Authorize(Permissions.Donation.Create)]
        public IActionResult Create()
        {
            return View(new Donation());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Donation model)
        {
            var donation = new Donation
            {
                FirstName= model.FirstName,
                LastName= model.LastName,
                Email= model.Email,
                PhoneNumber= model.PhoneNumber,
                Address= model.Address,
                Branch= model.Branch,
                Trust= model.Trust,
                paymentMethod= model.paymentMethod,
                Amount= model.Amount,
                DonationDate= model.DonationDate
            };
            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();
            TempData["ResultOk"] = "Record Added Successfully !";
            return RedirectToAction("Index");
        }
        [Authorize(Permissions.Donation.Edit)]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var donation = _context.Donations.FirstOrDefault(x => x.Id == id);
            if (donation != null)
            {
                var don = new Donation 
                {
                    FirstName = donation.FirstName,
                    LastName = donation.LastName,
                    Email= donation.Email,
                    PhoneNumber= donation.PhoneNumber,
                    Address= donation.Address,
                    Branch= donation.Branch,
                    Trust= donation.Trust,
                    paymentMethod= donation.paymentMethod,
                    Amount= donation.Amount,
                    DonationDate = donation.DonationDate
                };
                return View(don);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Donation model)
        {
            var don = await _context.Donations.FindAsync(model.Id);
            if (don != null)
            {
               don.FirstName = model.FirstName;
                don.LastName = model.LastName;
                don.Email = model.Email;
                don.PhoneNumber = model.PhoneNumber;
                don.Address = model.Address;
                don.Branch = model.Branch;
                don.Trust = model.Trust;
                don.paymentMethod = model.paymentMethod;
                don.Amount = model.Amount;
                don.DonationDate = model.DonationDate;
                await _context.SaveChangesAsync();
                TempData["ResultOk"] = "Record Updated Successfully !";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [Authorize(Permissions.Donation.Delete)]
        public IActionResult Delete(int id)
        {
            var don = _context.Donations.Find(id);
            don.IsDeleted = true;
            _context.SaveChanges();
            TempData["ResultOk"] = "Record Deleted Successfully !";
            return RedirectToAction("Index");
        }
    }
}
