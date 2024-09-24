using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.News;
using api.Models;

namespace api.Mappers
{
    public static class NewsMappers
    {
        public static NewsDto ToNewsDto(this News newsModel){
            return new NewsDto{
                Id = newsModel.Id,
                Title = newsModel.Title,
                Content = newsModel.Content,
                publicshed_Date = newsModel.publicshed_Date,
                MenuId = newsModel.MenuId
            };
        }
           public static News ToNewsFromCreate(this CreateNewsDtoRequest newsDto,int MenuId){
            return new News{
                Title = newsDto.Title,
                Content = newsDto.Content,
                MenuId = MenuId
            };
        }
          public static News ToNewsFromUpdate(this UpdateNewsDtoRequest newsDto){
            return new News{
                Title = newsDto.Title,
                Content = newsDto.Content 
            };
        }
    }
}