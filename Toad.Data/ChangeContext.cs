using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toad.Data
{
    public class ChangeContext : DbContext  //IdentityDbContext<ApplicationUser> TODO Fix me use this 
    {
        public ChangeContext() : base("DatabaseModelContainer")   
        {

        }
        public DbSet<ChangeTable> Change { get; set; }
        public DbSet<CategoriesTable> Categories { get; set; }
        public DbSet<TagTable> Tags { get; set; }
        public DbSet<UserChangeTable> UserChangesTable { get; set; }
        public DbSet<UserTable> UserTable { get; set; }
        public DbSet<ChangeTagTable> ChangeTagIds{ get; set; }
        public DbSet<CommentTable> CommentTable { get; set; }
        public DbSet<UserCommentTable> UserCommentTable { get; set; }
        public DbSet<VoteTable> VoteTable { get; set; }
        public DbSet<ChangePrecursorTable> ChangePrecursorTable { get; set; }
        public DbSet<ConstraintTable> ChangeConstraintTable { get; set; }
        public DbSet<ChangeFollowerTable> ChangeFollowerTable { get; set; }
        public DbSet<UserFollowers> UserFollowerTable { get; set; }
        public DbSet<ChildComment> ChildComment { get; set; }
        public DbSet<BlogTable> BlogTable { get; set; }
        public DbSet<FreeComment> FreeComment { get; set; }
    }
}