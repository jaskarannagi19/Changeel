using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toad.Web.Models
{
    public class PrecursorModel
    {
        public int Id { get; set; }
        public int ChangeId { get; set; }
        public DateTime TimeStamp { get; set; }
        public int UserId { get; set; }
        public int MainChangeId { get; set; }
    }
}