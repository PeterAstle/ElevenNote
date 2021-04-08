using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryListItem
    {

        public int CategoryId { get; set; }
        [Display(Name ="Category Name")]
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
