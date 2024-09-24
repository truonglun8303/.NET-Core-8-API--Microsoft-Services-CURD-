using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Menu;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Reponsitory
{
    public class MenuReponsitory : IMenuReponsitory
    {
        private readonly ApplicationDbContext _context;
        public MenuReponsitory(ApplicationDbContext context){
            _context = context;
        }

        public Task<Menu> CreateAsync(Menu menuModel)
        {
            throw new NotImplementedException();
        }

        public Task<Menu?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Menu>> GetAllAsync(){
            return await _context.menus.Include(x => x.News).ToListAsync();
        }
        public async Task<Menu?> GetByIdAsync(int id)
        {
            return await _context.menus.Include(x => x.News).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> MenuExists(int id)
        {
            return _context.menus.AnyAsync(x => x.Id == id);
        }

        public Task<Menu?> UpdateAsync(int id, UpdateMenuDtoRequest menuDto)
        {
            throw new NotImplementedException();
        }
    }
}