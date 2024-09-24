using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.News;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Reponsitory
{
    public class NewsReponsitory : INewsReponsitory
    {
        private readonly ApplicationDbContext _context;
        public NewsReponsitory(ApplicationDbContext context){
            _context = context;
        }
        public async Task<List<News>> GetAllAsync(){
            return await _context.news.ToListAsync();
        }
        public async Task<News?> GetByIdAsync(int id)
        {
            return await _context.news.FindAsync(id);
        }
          public async Task<News> CreateAsync(News newsModel)
        {
            await _context.news.AddAsync(newsModel);
            await _context.SaveChangesAsync();
            return newsModel;
        }

        public async Task<News?> UpdateAsync(int id, News newsModel)
        {
            var existingNews = await _context.news.FindAsync(id);

            if(existingNews == null){
                return null;
            }
            existingNews.Title = newsModel.Title;
            existingNews.Content = newsModel.Content;

            await _context.SaveChangesAsync();
            return existingNews;
        }

        public async Task<News?> DeleteAsync(int id)
        {
            var newsModel = await _context.news.FirstOrDefaultAsync(x => x.Id == id);
            if(newsModel == null){
                return null;
            }
            _context.news.Remove(newsModel);
            await _context.SaveChangesAsync();
            return newsModel;
        }
    }
}