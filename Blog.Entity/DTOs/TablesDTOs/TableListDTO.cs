using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.DTOs.TablesDTOs
{
    public class TableListDTO
    {
        public int Id { get; set; } // Masa ID'si
        public string TableNumber { get; set; } // Masa numarası
        public bool IsDeleted { get; set; } // Masa silinmiş mi
    }
}
