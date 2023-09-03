using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        //Dependency Injection
        private readonly KutuphaneContext _context;
        public YazarController(KutuphaneContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return Json(new { data = _context.Yazarlar.ToList() });
        }
               
        public IActionResult Delete(int id)
        {
            // Yazar yazar = _context.Yazarlar.Where(y => y.Id == id).First();

           // Yazar yazar = _context.Yazarlar.FirstOrDefault(x => x.Id == id);
          
            _context.Yazarlar.Remove(_context.Yazarlar.Find(id));

            _context.SaveChanges();


            return RedirectToAction("Index");

        }
             

        public IActionResult Upsert(int? id)
        {
            if (id != null)
            {
                return View(_context.Yazarlar.Find(id));
            }
            else {
                return View();
            }
          
        }
        [HttpPost]
        public IActionResult Upsert(Yazar yazar)
        {
            if(yazar.Id==0)
            {
                _context.Yazarlar.Add(yazar);
                _context.SaveChanges();
            }
            else
            {
                _context.Yazarlar.Update(yazar);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}
