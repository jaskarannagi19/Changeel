using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toad.Web.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public string IPAddress { get; set; }
        public string CommentID { get; set; }
        public int ChangeID { get; set; }
        public bool SeeMore { get; set; }
        public int TotalVotes { get; set; }
        public List<CommentModel> ChildComments { get; set; }
    }
}