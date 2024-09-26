using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.DTOs.TablesDTOs
{
    public class TableUpdateDTO
    {
        public int Id { get; set; } // Güncellenen masanın ID'si
        public string TableNumber { get; set; } // Güncellenen masa numarası
    }
}
