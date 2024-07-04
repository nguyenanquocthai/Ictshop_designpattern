using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ictshop.Design_Pattern.Facade
{
    public interface IUserAuthentication
    {
        bool Authenticate(string email, string password);
    }
}
