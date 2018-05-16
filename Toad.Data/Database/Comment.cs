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
    
    public partial class Comment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Comment()
        {
            this.UserComments = new HashSet<UserComment>();
            this.ProposalVotes = new HashSet<ProposalVote>();
        }
    
        public int Id { get; set; }
        public string Content { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public string IPAddress { get; set; }
        public int ChangeId { get; set; }
        public int TotalVote { get; set; }
    
        public virtual Change Change { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserComment> UserComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProposalVote> ProposalVotes { get; set; }
    }
}
