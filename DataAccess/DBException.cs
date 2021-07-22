using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public class DBException:Exception
    {
        public DBException(Exception innerException) : base("不能访问数据库", innerException)
        {

        }
    }
}
