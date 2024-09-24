using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class News
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string Content {get; set;} = string.Empty;
        public DateTime publicshed_Date {get; set;} = DateTime.Now;
        // FK
        public int? MenuId {get; set;}
        public Menu? Menu {get; set;}
    }
}