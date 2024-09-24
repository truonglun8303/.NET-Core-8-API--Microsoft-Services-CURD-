using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Menu;
using api.Models;

namespace api.Interface
{
    public interface IMenuReponsitory
    {
        Task<List<Menu>> GetAllAsync();
        Task<Menu?> GetByIdAsync(int id);
        Task<Menu> CreateAsync(Menu menuModel);
        Task<Menu?> UpdateAsync(int id, UpdateMenuDtoRequest menuDto);
        Task<Menu?> DeleteAsync(int id);
        Task<bool> MenuExists(int id);
    }
}