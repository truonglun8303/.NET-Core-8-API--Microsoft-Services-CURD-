using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Menu;
using api.Models;

namespace api.Mappers
{
    public static class MenuMappers
    {
       public static MenuDto ToMenuDto(this Menu menuModel){
            return new MenuDto
            {
                Id = menuModel.Id,
                Name = menuModel.Name,
                Description = menuModel.Description,
                news = menuModel.News.Select(x => x.ToNewsDto()).ToList()
            };
        }
        public static Menu ToMenuFromCreateDTO(this CreateMenuDtoRequest menuDto) 
        {
            return new Menu{
                Name = menuDto.Name,
                Description = menuDto.Description,
                
            };
        }

    }
}