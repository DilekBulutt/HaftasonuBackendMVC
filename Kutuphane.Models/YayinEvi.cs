using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Models
{
    [Table("YayinEvleri")]
    public class YayinEvi:BaseModel
    {
        public string Adres { get; set; }
        public string Tel { get; set; }

        public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
        public virtual ICollection<Yazar> Yazarlar { get; set; }= new List<Yazar>();

    }
}
