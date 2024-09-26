using Blog.Entity.DTOs.TablesDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstractions
{
    public interface ITabless
    {
        Task<TableDTO> CreateTableAsync(TableCreateDTO tableCreateDto);
        Task<TableDTO> UpdateTableAsync(TableUpdateDTO tableUpdateDto);
        Task<TableDTO> GetTableByIdAsync(int id);
        Task<List<TableDTO>> GetAllTablesAsync(bool includeDeleted = false);
        Task<bool> SoftDeleteTableAsync(int id);
        Task<bool> RestoreTableAsync(int id);
    }
}
