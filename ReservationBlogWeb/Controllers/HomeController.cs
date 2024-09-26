using Blog.Entity.DTOs.ReservationsDTOs;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReservationBlogWeb.Models;
using System.Diagnostics;

namespace ReservationBlogWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRezervationss _rezervationsService;
        private readonly ITabless _tabless;

        public HomeController(IRezervationss rezervationsService , ITabless tabless)
        {
            this._rezervationsService = rezervationsService;
            this._tabless = tabless;
        }




        public IActionResult Index()
        {
            return View();
        }

        // Rezervasyon oluþturma iþlemi
        [HttpGet]
        public async Task<IActionResult> Privacy()
        {
            // Tablolarý getir ve SelectList oluþtur
            var tables = await _tabless.GetAllTablesAsync();
            ViewBag.Tables = new SelectList(tables, "Id", "TableNumber"); // Table ID ve Table Number bilgisi gösterilecek

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Privacy(ReservationCreateDTO reservationCreateDto)
        {
            if (ModelState.IsValid)
            {
                await _rezervationsService.CreateReservationAsync(reservationCreateDto);
                return RedirectToAction(nameof(Index));
            }

            // Hatalý form durumunda tablolarý yeniden doldur
            var tables = await _tabless.GetAllTablesAsync();
            ViewBag.Tables = new SelectList(tables, "Id", "TableNumber");

            return View(reservationCreateDto);
        }

    }
}
