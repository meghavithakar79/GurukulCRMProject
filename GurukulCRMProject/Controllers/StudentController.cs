using Gurukul.Infrastructure.Constants;
using GurukulCRMProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GurukulCRMProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly GurukulDbContext _context;
        public StudentController(GurukulDbContext context)
        {
            _context = context;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Index()
        {
            var student = _context.Students.ToList();
            return View(student);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Student model) 
        {
            var students = new Student
            {
               FirstName = model.FirstName,
               LastName = model.LastName,
               Gender = model.Gender,
               DOB = model.DOB,
               Email = model.Email,
               PhoneNumber = model.PhoneNumber,
               Address = model.Address,
               School = model.School,
               Board = model.Board,
               Medium = model.Medium,
               Enrollment_Date = model.Enrollment_Date,
               CGPA=model.CGPA,
               Percentage=model.Percentage
            };
            await _context.Students.AddAsync(students);
            await _context.SaveChangesAsync();
            TempData["ResultOk"] = "Record Added Successfully !";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var stu = _context.Students.FirstOrDefault(x => x.Id == id);
            if (stu != null)
            {
                var student = new Student
                {
                   FirstName= stu.FirstName,
                   LastName= stu.LastName,
                   Gender = stu.Gender,
                   DOB = stu.DOB,
                   Email = stu.Email,
                   PhoneNumber = stu.PhoneNumber,
                   Address = stu.Address,
                   School = stu.School,
                   Board = stu.Board,
                   Medium = stu.Medium,
                   CGPA=stu.CGPA,
                   Percentage=stu.Percentage,
                   Enrollment_Date=stu.Enrollment_Date,
                };
                return View(student);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student model)
        {
            var stu = await _context.Students.FindAsync(model.Id);
            if (stu != null)
            {
                stu.FirstName = model.FirstName;
                stu.LastName = model.LastName;
                stu.Gender = model.Gender;
                stu.DOB = model.DOB;
                stu.Email = model.Email;
                stu.PhoneNumber = model.PhoneNumber;
                stu.Address = model.Address;
                stu.School = model.School;
                stu.Board = model.Board;
                stu.Medium = model.Medium;
                stu.CGPA = model.CGPA;
                stu.Percentage = model.Percentage;
                stu.Enrollment_Date = model.Enrollment_Date;
                await _context.SaveChangesAsync();
                TempData["ResultOk"] = "Record Updated Successfully !";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
