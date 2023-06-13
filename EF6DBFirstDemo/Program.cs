using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6DBFirstDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            while (true)
            {
                Console.WriteLine("1.Insert");
                Console.WriteLine("2.Update");
                Console.WriteLine("3.Delete");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            CURD.Insert();
                            break;
                        }
                    case 2:
                        {
                            CURD.Update();
                            break;
                        }
                    case 3:
                        {
                            CURD.Delete();
                            break;

                        }
                }
            }
        }
    }
}
