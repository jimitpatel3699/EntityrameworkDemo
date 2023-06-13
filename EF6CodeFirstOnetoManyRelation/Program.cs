using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstOnetoManyRelation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            while (true)
            {
                try
                {
                    Console.WriteLine("1.Insert Employee");
                    Console.WriteLine("2.Update Employee");
                    Console.WriteLine("3.Remove Employee");
                    Console.WriteLine("4.Search");
                    Console.WriteLine("5.Register Department");
                    Console.WriteLine("6.Update Department");
                    Console.WriteLine("7.Remove Department");
                    Console.WriteLine("Enter Choice:");
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
                        case 4:
                            {
                                Console.WriteLine("Enter DepartmentId:");
                                int deptId = Convert.ToInt32(Console.ReadLine());
                                CURD.Select(deptId);
                                break;
                            }
                        case 5:
                            {
                                CURD.RegisterDepartment();
                                break;
                            }
                        case 6:
                            {
                                CURD.UpdateDepartment();
                                break;
                            }
                        case 7:
                            {
                                CURD.RemoveDepartment();
                                break;
                            }
                    }
                
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
