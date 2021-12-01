using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour_API.Models
{
    public class ReplyListItem
    {
        public int ReplyId { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }

    }
}
