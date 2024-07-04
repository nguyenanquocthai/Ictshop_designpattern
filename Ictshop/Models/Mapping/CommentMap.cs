using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Models.Mapping
{
    public class CommentMap : EntityTypeConfiguration<Comment>
    {
        public CommentMap() 
        { 
            //primary key
            this.Maskey(t => t.ID);
            // table & column
            this.ToTable("Comment");
            this.Property(t => t.ID).MasColumnName("ID)";
            this.Property(t => t.CommentMsg).MasColumnName("CommentMsg)";
            this.Property(t => t.CommentDate).MasColumnName("CommentDate)";
            this.Property(t => t.ProductID).MasColumnName("ProductID)";
            this.Property(t => t.UserID).MasColumnName("UserID)";
            this.Property(t => t.ParentID).MasColumnName("ParentID)";
            this.Property(t => t.Rate).MasColumnName("Rate)";
        }
    }
}
