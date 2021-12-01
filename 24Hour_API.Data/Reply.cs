using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour_API.Data
{
    public class Reply
    {
        public int ReplyID { get; set; }
        [ForeignKey("CommentId")]
        public int CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public Guid AuthorId { get; set; }
    }
}
