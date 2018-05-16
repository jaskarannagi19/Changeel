using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toad.Web.Models
{
    public class FreeCommentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public int ChangeId { get; set; }
        public int BlogId { get; set; }
        public string IP { get; set; }
    }
}