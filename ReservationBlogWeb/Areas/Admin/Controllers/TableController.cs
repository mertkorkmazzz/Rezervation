using Blog.Entity.DTOs.TablesDTOs;
using Blog.Service.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReservationBlogWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TableController : Controller
    {


        //kayıylı masalar  -   masa ekleme  - masa sil & güncelle



        private readonly ITabless _table;
        public TableController(ITabless table)
        {
            this._table = table;
        }





        public async Task<IActionResult> TableList()
        {
            var tables = await _table.GetAllTablesAsync();
            return View(tables);
        }



        public  IActionResult TableAdd()
        {
         
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TableAdd(TableCreateDTO createDTO)
        {
            if (ModelState.IsValid)
            {
                await _table.CreateTableAsync(createDTO);
                return RedirectToAction(nameof(TableList));
            }
            return View(createDTO);
        }



        public async Task<IActionResult> TableUpdate(int id)
        {
            var table = await _table.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            var tableUpdateDto = new TableUpdateDTO
            {
                Id = table.Id,
                TableNumber = table.TableNumber
            };

            return View(tableUpdateDto);
        }  
        [HttpPost]
        public async Task<IActionResult> TableUpdate(TableUpdateDTO tableUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _table.UpdateTableAsync(tableUpdateDto);
                return RedirectToAction(nameof(TableList));
            }

            return View(tableUpdateDto);
        }




        public async Task<IActionResult> TableDelete(int id)
        {
            var table = await _table.GetTableByIdAsync(id);
            if (table == null)
            {
                return NotFound();
            }

            return View(table);
        }

        // Masa silme işlemi (POST)
        [HttpPost, ActionName("TableDelete")]
        public async Task<IActionResult> TableDeleteConfirmed(int id)
        {
            var success = await _table.SoftDeleteTableAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(TableList));
        }


     

        public async Task<IActionResult> TableDeletUpdate()
        {
            var tables = await _table.GetAllTablesAsync();
            return View(tables);
        }
    }
}
