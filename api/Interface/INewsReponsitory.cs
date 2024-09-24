using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.News;
using api.Models;

namespace api.Interface
{
    public interface INewsReponsitory
    {
        Task<List<News>> GetAllAsync();
        Task<News?> GetByIdAsync(int id);
        Task<News> CreateAsync(News newsModel);
        Task<News?> UpdateAsync(int id, News newsModel);
        
        Task<News?> DeleteAsync(int id);
    }
}