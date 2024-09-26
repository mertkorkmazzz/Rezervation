using Blog.Entity.DTOs.ReservationsDTOs;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReservationBlogWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    { 


        private readonly IRezervationss _rezervationss;
        private readonly ITabless _tabless;

        public AdminController(IRezervationss rezervationss ,ITabless tabless)
        {
            this._rezervationss = rezervationss;
            this._tabless = tabless;
        }


        public async Task<IActionResult> Index()
        {
            var reser = await _rezervationss.GetAllReservationsAsync();
            return View(reser);
        } //kayıtlı rezervasyonlar

        public async Task<IActionResult> Homee()
        {
             return View();
        }

        public async Task<IActionResult> RezerUpdate()
        {
            var reser = await _rezervationss.GetAllReservationsAsync();
            return View(reser);
        } //güncelleme sayfasına gider

       
        public async Task<IActionResult> Updates(int id)
        {
            var reservation = await _rezervationss.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            var tables = await _tabless.GetAllTablesAsync();

            var reservationUpdateDto = new ReservationUpdateDTO
            {
                Id = reservation.Id,
                FirstName = reservation.FirstName,
                LastName = reservation.LastName,
                PhoneNumber = reservation.PhoneNumber,
                ReservationDate = reservation.ReservationDate,
                TableId = reservation.TableId
            };

            ViewBag.Tables = new SelectList(tables, "Id", "TableNumber", reservation.TableId);
            return View(reservationUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Updates(ReservationUpdateDTO reservationUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _rezervationss.UpdateReservationAsync(reservationUpdateDto);
                return RedirectToAction(nameof(Index));
            }

            var tables = await _tabless.GetAllTablesAsync();
            ViewBag.Tables = new SelectList(tables, "Id", "TableNumber", reservationUpdateDto.TableId);

            return View(reservationUpdateDto);
        }
    }
}
