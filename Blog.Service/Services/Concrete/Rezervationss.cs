using AutoMapper;
using Blog.Dal.UnitOfWork;
using Blog.Entity.DTOs.ReservationsDTOs;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
    public class Rezervationss  : IRezervationss
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Rezervationss(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }




        // Tüm rezervasyonları getirir (İlişkili masalar dahil)
        public async Task<List<ReservationDTO>> GetAllReservationsAsync()
        {
            var reservations = await _unitOfWork.GetRepository<Reservation>()
                .GetAllAsync(x => !x.IsDeleted, x => x.Table); // İlişkili Table varlıklarını da dahil ediyoruz
            var mappedReservations = _mapper.Map<List<ReservationDTO>>(reservations);
            return mappedReservations;
        }

        // ID'ye göre tek rezervasyonu getirir
        public async Task<ReservationDTO> GetReservationByIdAsync(int id)
        {
            var reservation = await _unitOfWork.GetRepository<Reservation>()
                .GetAsync(x => x.Id == id, x => x.Table);
            if (reservation == null) throw new Exception("Reservation not found");

            var mappedReservation = _mapper.Map<ReservationDTO>(reservation);
            return mappedReservation;
        }

        // Yeni bir rezervasyon oluşturur
        public async Task CreateReservationAsync(ReservationCreateDTO reservationCreateDto)
        {
            var newReservation = _mapper.Map<Reservation>(reservationCreateDto); // DTO'yu entity'ye mapliyoruz
            await _unitOfWork.GetRepository<Reservation>().AddAsync(newReservation);
            await _unitOfWork.SaveAsync();
        }

        // Rezervasyonu günceller
        public async Task UpdateReservationAsync(ReservationUpdateDTO reservationUpdateDto)
        {
            var existingReservation = await _unitOfWork.GetRepository<Reservation>()
                .GetAsync(x => x.Id == reservationUpdateDto.Id);
            if (existingReservation == null) throw new Exception("Reservation not found");

            _mapper.Map(reservationUpdateDto, existingReservation); // DTO'yu entity'ye mapleyerek güncelliyoruz
            await _unitOfWork.GetRepository<Reservation>().UpdateAsync(existingReservation);
            await _unitOfWork.SaveAsync();
        }

        // Rezervasyonu siler (soft delete)
        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await _unitOfWork.GetRepository<Reservation>()
                .GetAsync(x => x.Id == id);
            if (reservation == null) throw new Exception("Reservation not found");

            reservation.IsDeleted = true;
            await _unitOfWork.GetRepository<Reservation>().UpdateAsync(reservation);
            await _unitOfWork.SaveAsync();
        }

        // Soft delete edilmiş rezervasyonları geri alır
        public async Task RestoreReservationAsync(int id)
        {
            var reservation = await _unitOfWork.GetRepository<Reservation>()
                .GetAsync(x => x.Id == id && x.IsDeleted);
            if (reservation == null) throw new Exception("Reservation not found or not deleted");

            reservation.IsDeleted = false;
            await _unitOfWork.GetRepository<Reservation>().UpdateAsync(reservation);
            await _unitOfWork.SaveAsync();
        }
    }
}
