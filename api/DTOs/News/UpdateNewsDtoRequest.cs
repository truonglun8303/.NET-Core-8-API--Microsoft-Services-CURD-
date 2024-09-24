using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.News
{
    public class UpdateNewsDtoRequest
    {
        [Required(ErrorMessage = "Title là bắt buộc")]
        public string Title {get; set;} = string.Empty;
        [Required(ErrorMessage = "Nội dung là bắt buộc")]
        public string Content {get; set;} = string.Empty;
        public DateTime publicshed_Date {get; set;} = DateTime.Now;
    }
}