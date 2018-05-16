using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toad.Web.Models
{
    public class VoteModel
    {
        public int ID { get; set; }
        public bool VoteStatus { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
    }
}