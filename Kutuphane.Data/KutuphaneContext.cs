using Kutuphane.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Data
{
    public class KutuphaneContext:DbContext
    {
        public KutuphaneContext()
        {
            
        }
        public KutuphaneContext(DbContextOptions<KutuphaneContext> options):base(options)
        {
            
        }

        public virtual DbSet<Yazar> Yazarlar { get; set; }
        public virtual DbSet<YayinEvi> YayinEvleri { get; set; }
        public virtual DbSet<Kitap> Kitaplar { get; set; }

    }
}
