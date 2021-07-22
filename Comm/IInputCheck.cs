using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Comm
{
    public interface IInputCheck
    {
        bool CheckBookID(string bookid);
        bool CheckISBN(string isbn);
        bool CheckPassWord(string password);
    }
}
