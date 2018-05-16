using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toad.Web.Models
{
    public class ConstraintModel
    {
        public int Id { get; set; }
        public int ChangeId { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}