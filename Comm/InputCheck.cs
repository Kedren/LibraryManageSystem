using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Comm
{
    public class InputCheck:IInputCheck
    {


        public bool CheckBookID(string bookid)
        {
            if(bookid.Length>6)
            {
                return true;
            }
            return false;
        }

        public bool CheckISBN(string isbn)
        {
            int checkNum = 0;
            int num = 10;
            int sum = 0;       
            if (isbn.Length == 10)
            {           
                for (int i = 0; i < isbn.Length - 1; i++)
                {
                    char c = Convert.ToChar(isbn.Substring(i,1));
                    int n = c - '0';
                    sum += n * num--;
                }
                checkNum = sum % 11;
                checkNum = 11 - checkNum;          
            }
            if (checkNum == 10 && isbn.Substring(isbn.Length - 1, 1) == "X")
            {
                return true;
            }
            if (isbn.Substring(isbn.Length-1, 1) == checkNum.ToString())
            {
                return true;
            }
            return false;
        }

        public bool CheckPassWord(string password)
        {
            if(password.Length<8||password.Length>16)
            {
                return false;
            }                
            return true;
        }
    }
}
