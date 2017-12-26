using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiTarea.Models
{
    public class IndexUrl { 

        [Required]
        public string Url { get; set; }
    }

}

