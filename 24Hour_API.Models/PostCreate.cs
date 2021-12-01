using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour_API.Models
{
    public class PostCreate
    {
        [Required]
        [Minlength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string Title { get; set; }
        [MaxLenght(8000)]
        public string Text { get; set; }
        public int PostId { get; set; }
    }
}
