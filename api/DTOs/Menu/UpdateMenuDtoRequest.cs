using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Menu
{
    public class UpdateMenuDtoRequest
    {
        [Required(ErrorMessage = "Tên Menu là bắt buộc")]
        public string Name {get; set;} = string.Empty;
        [Required(ErrorMessage = "Chi tiết là bắt buộc")]
        public string Description {get; set;} = string.Empty;
    }
}