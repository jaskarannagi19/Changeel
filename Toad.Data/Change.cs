using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toad.Data
{
    [Table("Changes")]
    public class ChangeTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
        public bool isPoll { get; set; }
        public bool IsDeleted { get; set; }
        public string SearchTitle { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ViewCounter { get; set; }
    }
}
