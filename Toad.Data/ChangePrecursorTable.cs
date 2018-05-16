using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toad.Data
{
    [Table("ChangePrecursors")]
    public class ChangePrecursorTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ChangeId { get; set; }
        public int UserId { get; set; }
        public int MainChangeId { get; set; }
    }
}
