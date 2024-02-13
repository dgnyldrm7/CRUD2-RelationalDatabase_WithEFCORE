using crud_productList.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_productList.Controllers
{
    public class KursController : Controller
    {
        private readonly DatabaseContext _context;

        public KursController(DatabaseContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var crs = await _context.Courses.ToListAsync();

            return View(crs);
        }

        [HttpPost]
        public async  Task<IActionResult> Index(Course course)
        {

            if (course == null)
            {
                return NotFound();
            }
            _context.Courses.Add(course);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> Set(int? id)
        {   
            if( id == null)
            {
                return NotFound();
            }

            var number = await _context.Courses.FindAsync(id);

            if ( number == null)
            {
                return NotFound();
            }
            
            return View(number);
        }

        [HttpPost]
        public async Task<IActionResult> Set(int? id, Course course)
        {
           

            if( id != course.CourseId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    throw;
                }

                return RedirectToAction("Index", "Home");
            }

            return View(course);
        }







        [HttpGet]
        public async Task<IActionResult> Del(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var IdGet = await _context.Courses.FindAsync(id);

            if (IdGet == null)
            {
                return NotFound();
            }

            return View(IdGet);
        }


        [HttpPost]
        public async Task<IActionResult> Del(int id)
        {

            var deger = await _context.Courses.FindAsync(id);
            if (deger == null)
            {
                return NotFound();
            }

            _context.Remove(deger);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }




    }
}
