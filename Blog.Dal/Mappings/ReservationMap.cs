using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Dal.Mappings
{
    public class ReservationMap : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasData(
                new Reservation
                {
                    Id = 1,
                    FirstName = "Ahmet",
                    LastName = "Yılmaz",
                    PhoneNumber = "123456789",
                    ReservationDate = new DateTime(2024, 9, 22, 19, 00, 00),
                    TableId = 1,
                    IsDeleted = true
                },
                new Reservation
                {
                    Id = 2,
                    FirstName = "Mehmet",
                    LastName = "Kaya",
                    PhoneNumber = "987654321",
                    ReservationDate = new DateTime(2024, 9, 23, 18, 30, 00),
                    TableId = 2,
                    IsDeleted = false
                }
            );
        }
    }
}
