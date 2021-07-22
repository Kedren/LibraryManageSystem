using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Library.Comm
{
    public class Encrypt:IEncrypt
    {
        public byte[] EncryptPassWord(string password)
        {
            ASCIIEncoding en = new ASCIIEncoding();
            byte[] pwd = en.GetBytes(password);

            SHA1Managed sha = new SHA1Managed();
            return sha.ComputeHash(pwd);
        }
    }
}
