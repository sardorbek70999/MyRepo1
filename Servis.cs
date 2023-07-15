using RestoranManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Modul_Imtixon_1_Savol
{
    public delegate void RunServis();

    public  class Servis:Program
    {

     
        public static void RunServis()
        {
            Program _program = new Program();
            RunServis run = new(Run1);
            {
               Run1();
            };
        }
        public static void Run1()
        {
            Console.WriteLine("Taomnoma Qoshildi!");
        }
    }
}
