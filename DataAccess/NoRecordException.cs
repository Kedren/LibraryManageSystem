using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class NoRecordException:Exception
    {
      public NoRecordException() : base("没有这条记录")
      {

      }
      public NoRecordException(string message) : base(message)
      {

      }

    }
}
