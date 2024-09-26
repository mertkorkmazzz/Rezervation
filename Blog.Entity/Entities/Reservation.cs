using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Reservation
    {
        public int Id { get; set; } // Benzersiz kimlik
        public string FirstName { get; set; } // Kullanıcının adı
        public string LastName { get; set; } // Kullanıcının soyadı
        public string PhoneNumber { get; set; } // Kullanıcının telefon numarası
        public DateTime ReservationDate { get; set; } // Rezervasyon tarihi
        public int TableId { get; set; } // Masa kimliği
        public bool IsDeleted { get; set; } = false; // Rezervasyon silindi mi (geçmiş rezervasyonlar için)

        public Table Table { get; set; } // İlişkili masa
    }
}
