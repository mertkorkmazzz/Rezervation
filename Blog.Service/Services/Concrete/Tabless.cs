using AutoMapper;
using Blog.Dal.UnitOfWork;
using Blog.Entity.DTOs.TablesDTOs;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
    public class Tabless : ITabless
    {




        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Tabless(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }




        // Create a new table
        public async Task<TableDTO> CreateTableAsync(TableCreateDTO tableCreateDto)
        {
            var table = _mapper.Map<Table>(tableCreateDto);
            await _unitOfWork.GetRepository<Table>().AddAsync(table);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<TableDTO>(table);
        }

        // Update an existing table
        public async Task<TableDTO> UpdateTableAsync(TableUpdateDTO tableUpdateDto)
        {
            var table = await _unitOfWork.GetRepository<Table>().GetByGuidAsync(tableUpdateDto.Id);
            if (table == null)
            {
                // Handle not found case
                return null;
            }

            table.TableNumber = tableUpdateDto.TableNumber;
            await _unitOfWork.GetRepository<Table>().UpdateAsync(table);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<TableDTO>(table);
        }

        // Get a table by its ID
        public async Task<TableDTO> GetTableByIdAsync(int id)
        {
            var table = await _unitOfWork.GetRepository<Table>().GetByGuidAsync(id);
            if (table == null)
            {
                return null;
            }

            return _mapper.Map<TableDTO>(table);
        }

        // Get all tables (including deleted option)
        public async Task<List<TableDTO>> GetAllTablesAsync(bool includeDeleted = false)
        {
            var tables = await _unitOfWork.GetRepository<Table>().GetAllAsync(t => includeDeleted || !t.IsDeleted);
            return _mapper.Map<List<TableDTO>>(tables);
        }

        // Soft delete a table
        public async Task<bool> SoftDeleteTableAsync(int id)
        {
            var table = await _unitOfWork.GetRepository<Table>().GetByGuidAsync(id);
            if (table == null)
            {
                return false;
            }

            table.IsDeleted = true;
            await _unitOfWork.GetRepository<Table>().UpdateAsync(table);
            await _unitOfWork.SaveAsync();

            return true;
        }

        // Restore a deleted table
        public async Task<bool> RestoreTableAsync(int id)
        {
            var table = await _unitOfWork.GetRepository<Table>().GetByGuidAsync(id);
            if (table == null || !table.IsDeleted)
            {
                return false;
            }

            table.IsDeleted = false;
            await _unitOfWork.GetRepository<Table>().UpdateAsync(table);
            await _unitOfWork.SaveAsync();

            return true;
        }


    }
}

