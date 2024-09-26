using AutoMapper;
using Blog.Entity.DTOs.ReservationsDTOs;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.AutpMapperS.Reserves
{
    public class ReserveProfile : Profile
    {
        public ReserveProfile()
        {
            CreateMap<Reservation, ReservationDTO>()
                .ForMember(dest => dest.TableNumber, opt => opt.MapFrom(src => src.Table.TableNumber)); // Masa numarası, ilişkili masadan alınır.

            // DTO -> Entity Mapping
            CreateMap<ReservationDTO, Reservation>();

            // Reservation -> ReservationCreateDTO Mapping
            CreateMap<Reservation, ReservationCreateDTO>().ReverseMap();

            // Reservation -> ReservationUpdateDTO Mapping
            CreateMap<Reservation, ReservationUpdateDTO>().ReverseMap();
        }
    }
}
