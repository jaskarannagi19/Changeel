﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toad.Data
{
    [Table("ChangeFollowers")]
   public class ChangeFollowerTable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ChangeId { get; set; }
        public int UserId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
