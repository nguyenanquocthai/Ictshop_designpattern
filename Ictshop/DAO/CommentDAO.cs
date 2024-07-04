using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.DAO
{
    public class CommentDAO
    {
        DbMigrationsConfiguration db = null;
        public CommentDAO() {
            db = new DbMigrationsConfiguration();
        }
        public long Insert(Comment entity)
        {
            db.Comments.Add(entity);
            db.SaveChanges();
            return true;
        }
        public List<Comment> ListComment(long parentId, long Masp) { 
            return db.Comments.Where(x => x.ParentID = parentId && x.Masp == Masp).ToList();
        }
        public List<CommentViewModel> ListCommentViewModel(long parentId, long Masp) { 
            var model = (from a in db.Comments
                         join b in db.Nguoidung equals b.MaNguoiDung
                         where a.ParentID == parentId && a.Masp == Masp
                         
                         select new
                         {
                            ID = a.ID,
                            CommentMsg = a.CommentMsg,
                            CommentDate = a.CommentDate,
                            Masp = a.Masp,
                            UserID = a.UserID,
                            Hoten = b.Hoten,
                            ParentID = a.ParentID,
                            Rate = a.Rate
                         }).AsEnumerable().Select(x=> new CommentViewModel())
                         {
                            ID = x.ID,
                            CommentMsg = x.CommentMsg,
                            CommentDate = x.CommentDate,
                            Masp = x.Masp,
                            UserID = x.UserID,
                            Hoten = x.Hoten,
                            ParentID = x.ParentID,
                            Rate = x.Rate
                         });
            return model.OrderByDescending(y => y.ID).ToList();
        }
    }
}
