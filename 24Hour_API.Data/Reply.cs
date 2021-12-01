using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour_API.Data
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }
        public string Text { get; set; }
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public Guid AuthorId { get; set; }
    }
}
