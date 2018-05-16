using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toad.Web.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public string BaseImage { get; set; }
        public int UserId { get; set; }
        public string SmallDescription { get; set; }
    }
}