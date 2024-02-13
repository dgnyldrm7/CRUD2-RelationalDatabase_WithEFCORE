using System.Globalization;
using System.Xml.Linq;
using crud_productList.Data;
using crud_productList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace crud_productList.Controllers
{
    public class HomeController : Controller
    {

        private readonly DatabaseContext _dbContext;
        
        public HomeController(DatabaseContext context)
        {
            _dbContext = context;
        }


        [HttpGet]
        public IActionResult Index(String searchstring)
        {


            var products = Repository.Products;

            if (!String.IsNullOrEmpty(searchstring))
            {
                products = products.Where(p => p.Description.ToLower().Contains(searchstring)).ToList();

               
            }
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }


        [HttpPost]
        public IActionResult Create(Product product , IFormFile inputGroupFile02)
        {
            if(ModelState.IsValid)
            {
                Repository.AddProduct(product);
                return View(product);
            }
            else
            {
                return View(product);
            }
        }



        //verileri listeleme işlemi
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var ogrenciler = await _dbContext.Students.ToListAsync();

            


            return View(ogrenciler);
        }


        //Verileri ekleme işlemi
        [HttpPost]
        public async Task<IActionResult> List(Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();



            return View("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }

            var ogr = await _dbContext.Students
                                               .Include(o => o.Etiket)
                                               .ThenInclude(m => m.Course)
                                               .FirstOrDefaultAsync(m => m.StudentId == id);

            if( ogr == null)
            {
                return NotFound();
            }

            return View(ogr);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id , Student model)
        {
            if( id != model.StudentId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(model);
                    await _dbContext.SaveChangesAsync();
                }

                catch (Exception) 
                {
                    throw;
                }

                return RedirectToAction("Index", "Home");
  
            }
            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> delete(int? id)
        {
            if( id == null)
            {
                return NotFound();
            }

            var dlt = await _dbContext.Students.FindAsync(id);

            if( dlt == null )
            {
                return NotFound();
            }

            return View(dlt);
        }

        [HttpPost]
        public async Task<IActionResult> delete(int id)
        {
            var studentToDelete = await _dbContext.Students.FindAsync(id);
            if (studentToDelete == null)
            {
                return NotFound();
            }

            _dbContext.Students.Remove(studentToDelete);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("List"); // List action'ına yönlendirme
        }








    }
}
