using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Menu;
using api.DTOs.News;
using api.Interface;
using api.Mappers;
using api.Migrations;
using api.Models;
using api.Reponsitory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controller
{
    [Route("api/news")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsReponsitory _newsRepo;
        private readonly IMenuReponsitory _menuRepo;
        public NewsController(INewsReponsitory newsRepo, IMenuReponsitory menuRepo)
        {
            _newsRepo = newsRepo;
            _menuRepo = menuRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var news = await _newsRepo.GetAllAsync();
                var NewsDto = news.Select(x => x.ToNewsDto());
                return Ok(NewsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy thông tin News", error = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var news = await _newsRepo.GetByIdAsync(id);
                if (news == null)
                {
                    return NotFound();
                }
                return Ok(news.ToNewsDto());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy thông tin từ Id: {id}", error = ex.Message });
            }
        }
        [HttpPost("{MenuId}")]
        public async Task<IActionResult> Create([FromRoute] int MenuId, [FromBody] CreateNewsDtoRequest newsDto)
        {
            try
            {
                // Kiểm tra xem Menu có tồn tại không
                if (!await _menuRepo.MenuExists(MenuId))
                {
                    return BadRequest("Menu không tồn tại");
                }
                // Chuyển DTO thành mô hình News và thiết lập MenuId
                var newsModel = newsDto.ToNewsFromCreate(MenuId);
                // Tạo bản ghi News mới
                await _newsRepo.CreateAsync(newsModel);
                // Trả về bản ghi mới được tạo với đường dẫn để lấy dữ liệu chi tiết
                return CreatedAtAction(nameof(GetById), new { id = newsModel.Id }, new { message = "News đã được tạo thành công rồi hihi", data = newsModel.ToNewsDto() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Không thể tạo News này", error = ex.Message });
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateNewsDtoRequest updateDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var news = await _newsRepo.UpdateAsync(id, updateDTO.ToNewsFromUpdate());

                if (news == null)
                {
                    return NotFound("Không tìm thấy Newsssss");
                };
                return Ok(new { message = "Cập nhật news thành công ", data = news.ToNewsDto() });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Cập nhật news đã xảy ra lỗi", error = ex.Message });
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newsModel = await _newsRepo.DeleteAsync(id);
                if (newsModel == null)
                {
                    return NotFound("Không tồn tại Id này");
                }
                return Ok(new { message = "Xoá thành công" });

            }
            catch(Exception ex){
                return StatusCode(500,new{message = "Xoá News này đã xảy ra lỗi", error = ex.Message});
            }
        }

    }
}