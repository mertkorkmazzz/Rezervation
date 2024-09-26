using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Table
    {
        public int Id { get; set; } // Masa Kimliği
        public string TableNumber { get; set; } // Masa numarası
        public bool IsDeleted { get; set; } = false; // Masa silindi mi (aktiflik durumu)

        public ICollection<Reservation> Reservations { get; set; } // Bu masaya ait rezervasyonlar
    }
}
