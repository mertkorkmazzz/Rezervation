using AutoMapper;
using Blog.Entity.DTOs.TablesDTOs;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.AutpMapperS.Tables
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            // Table -> TableDTO Mapping
            CreateMap<Table, TableDTO>().ReverseMap();

            // Table -> TableCreateDTO Mapping
            CreateMap<Table, TableCreateDTO>().ReverseMap();

            // Table -> TableUpdateDTO Mapping
            CreateMap<Table, TableUpdateDTO>().ReverseMap();

            // Table -> TableListDTO Mapping
            CreateMap<Table, TableListDTO>().ReverseMap();
        }
    }
}
