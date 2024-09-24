using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs.Menu;
using api.Interface;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace api.Controller
{
   [Route("api/menu")]
   [ApiController]
   public class MenuController : ControllerBase
   {
      private readonly ApplicationDbContext _context;
      private readonly IMenuReponsitory _menuRepo;
      public MenuController(ApplicationDbContext context, IMenuReponsitory menuRepo)
      {
         _menuRepo = menuRepo;
         _context = context;
      }
      [HttpGet]
      public async Task<IActionResult> GetAll()
      {
         try
         {
            var menus = await _menuRepo.GetAllAsync();
            var menuDto = menus.Select(s => s.ToMenuDto());
            return Ok(menus);
         }
         catch (Exception ex)
         {
            return StatusCode(500, new { message = "Đã xảy ra lỗi khi lấy Menu", error = ex.Message });
         }
      }
      [HttpGet("{id}")]
      // Sư dụng parameter ([FromRoute]) để nhận id từ URL
      public async Task<IActionResult> GetById([FromRoute] int id)
      {
         try
         {
            var menu = await _context.menus.FindAsync(id);
            if (menu == null)
            {
               return NotFound(new { message = "Không tìm thấy Id này" });
            }
            return Ok(menu);
         }
         catch (Exception ex)
         {
            return StatusCode(500, new { message = $"Đã xảy ra lỗi Menu của id: {id}", error = ex.Message });
         }
      }
      [HttpPost]
      public async Task<IActionResult> Create([FromBody] CreateMenuDtoRequest menuDto)
      {
         try
         {
            if (!ModelState.IsValid)
            {
               return BadRequest(ModelState);
            }
            var menuModel = menuDto.ToMenuFromCreateDTO();
            await _context.menus.AddAsync(menuModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = menuModel.Id }, new { message = "Tạo menu thành côgn", data = menuModel.ToMenuDto() });
         }
         catch (Exception ex)
         {
            return StatusCode(500, new { message = $"Đã xảy ra lỗi khi tạo menu", error = ex.Message });
         }
      }
      [HttpPut]
      [Route("{id}")]
      public async Task<ActionResult> Update([FromRoute] int id, [FromBody] UpdateMenuDtoRequest updateDto)
      {
         try
         {
            if (!ModelState.IsValid)
            {
               return BadRequest(ModelState);
            }
            var menuModel = await _context.menus.FirstOrDefaultAsync(x => x.Id == id);
            if (menuModel == null)
            {
               return NotFound();
            }
            menuModel.Name = updateDto.Name;
            menuModel.Description = updateDto.Description;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Cập nhật menu thành công", data = menuModel.ToMenuDto() });
         }
         catch(Exception ex){
            return StatusCode(500, new { message = $"Đã xảy ra lỗi khi sửa thông tin menu", error = ex.Message });
         }
      }
      [HttpDelete]
      [Route("{id}")]
      public async Task<IActionResult> Delete([FromRoute] int id)
      {
         try
         {
            var menuModel = _context.menus.FirstOrDefault(x => x.Id == id);
            if (menuModel == null)
            {
               return NotFound();
            }
            _context.menus.Remove(menuModel);
            await _context.SaveChangesAsync();
            return Ok("Xoá thành công");
         }
         catch (Exception ex)
         {
            return StatusCode(500, new { message = $"Đã xảy ra lỗi khi xoá menu", error = ex.Message });
         }
      }
   }
}