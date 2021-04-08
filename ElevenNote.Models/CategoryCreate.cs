﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
   public class CategoryCreate
    {
        [Required]
        [MinLength(2, ErrorMessage ="Please enter at least 2 characters.")]
        [MaxLength(50, ErrorMessage ="Please choose a shorter title.")]
        public string Title { get; set; }


        public string Description { get; set; }
    }
}
