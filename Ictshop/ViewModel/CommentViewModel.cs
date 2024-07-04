using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.ViewModel
{
    public class CommentViewModel
    {
        public long ID { get; set; }
        public string CommentMsg { get; set; }
        public Nullable<System.DateTime> CommentDate { get; set; }
        public long ProductID { get; set; }
        public long UserID { get; set; }
        public string Hoten {  get; set; }
        public long ParentID { get; set; }
        public int Rate { get; set; }
    }
}
