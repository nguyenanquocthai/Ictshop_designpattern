using Ictshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.Facade
{
    public class UserAuthenticationFacade : IUserAuthentication
    {
        Qlbanhang db = new Qlbanhang();

        public UserAuthenticationFacade(YourDbContext dbContext)
        {
            db = dbContext;
        }

        public bool Authenticate(string email, string password)
        {
            var islogin = db.Nguoidungs.SingleOrDefault(x => x.Email.Equals(email) && x.Matkhau.Equals(password));
            return islogin != null;
        }
    }
}
