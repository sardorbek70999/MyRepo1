using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Modul_Imtixon_1_Savol
{
    internal class MyException : Exception
    {
        MyException (string message) : base (message)
        {
            Console.WriteLine("Xatolik!!!");
        }
    }
}
