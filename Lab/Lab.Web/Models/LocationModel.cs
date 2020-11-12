using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.Web.Models
{
    public class LocationModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="La ciudad no puede estar vacia")]
        public string City { get; set; }

    }
}