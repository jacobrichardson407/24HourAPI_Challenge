using _24Hour_API.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour_API.Models
{
    public class ReplyCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(8000)]
        public string Text { get; set; }
        public int ReplyId { get; set; }
        [ForeignKey("CommentId")]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
