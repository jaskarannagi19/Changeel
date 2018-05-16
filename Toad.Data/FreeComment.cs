using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toad.Data
{
    [Table("FreeComments")]
   public class FreeComment
   {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        public string Email { get; set; }
        public int BlogId { get; set; }
        public int ChangeId { get; set; }
        public string IP { get; set; }
   }
}
