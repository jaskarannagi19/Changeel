//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Toad.Data.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserChange
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChangeId { get; set; }
    
        public virtual Change Change { get; set; }
        public virtual User User { get; set; }
    }
}
