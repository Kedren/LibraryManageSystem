using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Library.Comm
{
    public class Photo
    {
        public static byte[] ReadPhooto(string photoPath)
        {
            FileStream f = new FileStream(photoPath, FileMode.Open, FileAccess.Read);

            BinaryReader re = new BinaryReader(f); //创建二进制读取器
            return re.ReadBytes((int)f.Length);  // 返回byte[]数组
        }
    }
}
