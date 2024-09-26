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
    public class TableMap : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasData(
              new Table
              {
                  Id = 1,
                  TableNumber = "Masa 1",
                  IsDeleted = true
              },
              new Table
              {
                  Id = 2,
                  TableNumber = "Masa 2",
                  IsDeleted = false
              }
          );
        }
    }
}
