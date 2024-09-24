using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Menu
{
    public class CreateMenuDtoRequest
    {
        [Required(ErrorMessage = "Tên Menu là bắt buộc")]
        public string Name {get; set;} = string.Empty;
        [Required(ErrorMessage = "Chi tiết là bắt buộc")]
        public string Description {get; set;} = string.Empty;
    }
}