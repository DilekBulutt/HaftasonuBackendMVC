using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class YayinEviController : Controller
    {
        private readonly KutuphaneContext _context;

        public YayinEviController(KutuphaneContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult GetAll()
        {
            return Json(_context.YayinEvleri.ToList());
        }


        //bu metot sadece yayin evi eklemek için bize bir sayfa servis eden bir metotdur:
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(YayinEvi yayinEvi)
        {
            _context.YayinEvleri.Add(yayinEvi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
          
           _context.YayinEvleri.Remove( _context.YayinEvleri.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteAjax(int id)
        {

            _context.YayinEvleri.Remove(_context.YayinEvleri.Find(id));
            _context.SaveChanges();
            return Ok("Çalıştım");
        }



        public IActionResult Update(int id)
        {
            return View(_context.YayinEvleri.Find(id));
        }

        [HttpPost]
        public IActionResult Update(YayinEvi yayinEvi)
        {
            _context.YayinEvleri.Update(yayinEvi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Upsert(int? id)
        {
            if(id==0)
            {
                return View();
            }
            else
            {
                return View(_context.YayinEvleri.Find(id));
            }
        }

        [HttpPost]
        public IActionResult Upsert(YayinEvi yayinEvi)
        {
            if (yayinEvi != null)
            {
                if (yayinEvi.Id == 0)
                {
                    _context.YayinEvleri.Add(yayinEvi);
                }
                else
                {
                    _context.YayinEvleri.Update(yayinEvi);
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index");   
        }
    }
}
