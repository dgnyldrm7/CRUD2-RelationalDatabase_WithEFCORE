using crud_productList.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace crud_productList.Controllers
{
    public class KursKayitController : Controller
    {
        private readonly DatabaseContext _context;

        public KursKayitController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.Student = new SelectList(await _context.Students.ToListAsync() , "StudentId", "FullName");
            ViewBag.Course = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "CourseName");


            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Ekleme(ShowCourse kayit)
        {
            _context.Shows.Add(kayit);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Siralama()
        {
            var gelenDatalar = await _context.Shows.Include(x => x.Course)
                                                   .Include(y => y.Student)
                                                   .ToListAsync();

            return View(gelenDatalar);
        }



        
    }
}
