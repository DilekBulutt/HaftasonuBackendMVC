using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kutuphane.Controllers
{
    public class KitapController:Controller
    {
        //dependency injection ile contextimizi çekelim
        private readonly KutuphaneContext _context;

        public KitapController(KutuphaneContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View(_context.Kitaplar.Include(k => k.YayinEvleri).Include(k => k.Yazarlar).ToList());
        }

        public IActionResult Add()
        {
            ViewData["Yazarlar"] = _context.Yazarlar.ToList();
            ViewData["YayinEvleri"] = _context.YayinEvleri.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Add(Kitap kitap, List<int> yazarlar,List<int> yayinEvleri)
        {
            foreach(int s in yazarlar)
                kitap.Yazarlar.Add(_context.Yazarlar.Find(s));
            
            foreach (int s in yayinEvleri)
                kitap.YayinEvleri.Add(_context.YayinEvleri.Find(s));

         
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            ViewData["Yazarlar"] = _context.Yazarlar.ToList();
            ViewData["YayinEvleri"] = _context.YayinEvleri.ToList();


            return View(_context.Kitaplar.Include(k => k.Yazarlar).Include(k => k.YayinEvleri).FirstOrDefault(k => k.Id == id));
        }

        [HttpPost]
        public IActionResult Update(Kitap kitap, List<int> yazarlar, List<int> yayinEvleri)
        {
            Kitap asil = _context.Kitaplar.Include(k=>k.YayinEvleri).Include(k=>k.Yazarlar).FirstOrDefault(k=>k.Id==kitap.Id);

            asil.Ad = kitap.Ad;
            asil.ISBN = kitap.ISBN;

            List<Yazar> yazarListesi = new List<Yazar>();
            List<YayinEvi> yayinEvleriListesi = new List<YayinEvi>();
            foreach (int s in yazarlar)
                yazarListesi.Add(_context.Yazarlar.Find(s));

            foreach (int s in yayinEvleri)
               yayinEvleriListesi.Add(_context.YayinEvleri.Find(s));

            asil.Yazarlar = yazarListesi;
            asil.YayinEvleri = yayinEvleriListesi;


            _context.Kitaplar.Update(asil);
            _context.SaveChanges();
            return RedirectToAction("Index");



        }
    }
}
