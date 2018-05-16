using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toad.Data
{
    [Table("Users")]
    public class UserTable
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AspNetUserId { get; set; }
        public string TagLine { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Gender { get; set; }
        
    }
}   
