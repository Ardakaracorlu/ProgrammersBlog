using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="{0} boş geçilmemelidir. ")] // buradaki {0} Dinamiktir İçine Kategori Adı gelir, 1 ise uzunluğu gelir.
        [MaxLength(70,ErrorMessage ="{0,{1} Karakterden büyük olmamalıdır.")]
        [MinLength(3,ErrorMessage ="{0,{1} Karakterden az olmamalıdır. !")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")] 
        [MaxLength(500, ErrorMessage = "{0,{1} Karakterden büyük olmamalıdır !")]
        [MinLength(3, ErrorMessage = "{0,{1} Karakterden az olmamalıdır !")]
        public string Description { get; set; }

        [DisplayName("Kategori Özel Not Alanı")]
        [MaxLength(70, ErrorMessage = "{0,{1} Karakterden büyük olmamalıdır !")]
        [MinLength(3, ErrorMessage = "{0,{1} Karakterden az olmamalıdır !")]
        public string Note { get; set; }

        [DisplayName("Aktif Mi?")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir. !")]
        public bool IsActıve { get; set; }

    }
}
