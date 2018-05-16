using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Toad.Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TagLine { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Gender { get; set; }
    }
}