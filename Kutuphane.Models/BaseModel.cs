using System.ComponentModel.DataAnnotations;

namespace Kutuphane.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Ad { get; set; }

    }
}
