using Blog.Entity.DTOs.ReservationsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstractions
{
    public interface IRezervationss
    {
        Task<List<ReservationDTO>> GetAllReservationsAsync();
        Task<ReservationDTO> GetReservationByIdAsync(int id);
        Task CreateReservationAsync(ReservationCreateDTO reservationCreateDto);
        Task UpdateReservationAsync(ReservationUpdateDTO reservationUpdateDto);
        Task DeleteReservationAsync(int id);
        Task RestoreReservationAsync(int id);
    }
}
