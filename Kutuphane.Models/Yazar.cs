using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Models
{
    [Table("Yazarlar")]
    public class Yazar:BaseModel
    {
        public string? Ozgecmis { get; set; }
        public virtual ICollection<Kitap> Kitaplar { get; set; } = new List<Kitap>();
        public virtual ICollection<YayinEvi> YayinEvleri { get; set; }=new List<YayinEvi>();
    }
}
