using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.DTOs.ReservationsDTOs
{
    public class ReservationUpdateDTO
    {
        public int Id { get; set; } // Rezervasyon ID'si
        public string FirstName { get; set; } // Kullanıcının adı
        public string LastName { get; set; } // Kullanıcının soyadı
        public string PhoneNumber { get; set; } // Kullanıcının telefon numarası
        public DateTime ReservationDate { get; set; } // Rezervasyon tarihi
        public int TableId { get; set; } // Güncellenen masa ID'si
    }
}
