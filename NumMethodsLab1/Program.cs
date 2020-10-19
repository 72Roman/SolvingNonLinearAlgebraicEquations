using System;
using System.IO;
using Microsoft.CSharp;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using MathNet.Numerics;
using NumMethodsLab1;

namespace NumMetodsLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            Func<MyFunction, double> getRootFunction = null;
            Console.WriteLine("1. Вивести корені алгебреїчного рівняння методом Лобачевсього." +
                "\n2. Уточнити корені рівнянь за допомогою методів задані за варіантом.");
            string option = Console.ReadLine().Trim();

            if (option == "1")
            {
                double[] roots = LobachevskyiMethod.solve();

                while (true)
                {
                    Console.WriteLine("\n\nВиберiть метод уточнення коренів :" +
                     "\n  1. Метод хорд-дотичних." +
                     "\n  2. Метод хорд." +
                     "\n  3. Метод простих ітерацій." +
                     "\n  4. Вийти.");

                    string method = Console.ReadLine().Trim();

                    if (method == "4")
                    {
                        break;
                    }
                    else if (method != "1" && method != "2" & method != "3")
                    {
                        Console.WriteLine("Такого методу немає. Спробуйте ще раз.");
                        continue;
                    }

                    Console.WriteLine("Ввeдiть точнiсть або залиште рядок пустим [ eps = 10^(-7) ] :");

                    string strEps = Console.ReadLine();
                    double eps = string.IsNullOrEmpty(strEps) ? Math.Pow(10, -7) : Convert.ToDouble(strEps);

                    if (method == "1")
                    {
                        getRootFunction = CombinedMethod.getRoot;
                        Console.WriteLine("----------------- Метод хорд-дотичних -----------------");
                    }
                    else if (method == "2")
                    {
                        getRootFunction = HordMethod.getRoot;
                        Console.WriteLine("----------------- Метод хорд -----------------");

                    }
                    else if (method == "3")
                    {
                        getRootFunction = MPI.getRoot;
                        Console.WriteLine("----------------- Метод простих ітерацій -----------------");
                    }
                    try
                    {
                        double[] newRoots = LobachevskyiMethod.getRootsBySomeMethod(roots, getRootFunction, eps);
                        Console.WriteLine("\nУточнені корені рівняння методом хорд:\n ");

                        for (int i = 0; i < newRoots.Length; i++)
                        {
                            Console.WriteLine("Корінь до уточнення: " + roots[i] + " . Після уточнення: " + newRoots[i]);
                        }

                        Console.ReadKey();
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                }

            }
            else if (option == "2")
            {

                while (true)
                {
                    Console.WriteLine("\n\nВиберiть метод уточнення коренів :" +
                     "\n  1. Метод хорд-дотичних." +
                     "\n  2. Метод хорд." +
                     "\n  3. Метод простих ітерацій." +
                     "\n  4. Вийти.");

                    string method = Console.ReadLine().Trim();

                    if (method == "4")
                    {
                        break;
                    }
                    else if (method != "1" && method != "2" & method != "3")
                    {
                        Console.WriteLine("Такого методу немає. Спробуйте ще раз.");
                        continue;
                    }
                    Console.WriteLine("Введiть промiжок локалiзацii: [a, b] ( два значення, роздiленi пробiлом, де a < b)");
                    string[] tokens = Console.ReadLine().Split();
                    double a = double.Parse(tokens[0]);
                    double b = double.Parse(tokens[1]);

                    Console.WriteLine("Ввeдiть точнiсть або залиште рядок пустим [ epsilon = 10^(-7) ] :");

                    string strEps = Console.ReadLine();
                    double eps = string.IsNullOrEmpty(strEps) ? Math.Pow(10, -7) : Convert.ToDouble(strEps);

                    MyFunction myFunction = new MyFunction(a, b);
                    myFunction.setEps(eps);

                    if (method == "1")
                    {
                        getRootFunction = CombinedMethod.getRoot;
                        myFunction.setF(Functions.f1);
                        Console.WriteLine("----------------- Метод хорд-дотичних -----------------");
                    }
                    else if (method == "2")
                    {
                        getRootFunction = HordMethod.getRoot;
                        myFunction.setF(Functions.f2);
                        Console.WriteLine("----------------- Метод хорд -----------------");

                    }
                    else if (method == "3")
                    {
                        getRootFunction = MPI.getRoot;
                        Console.WriteLine("----------------- Метод простих ітерацій -----------------");
                        myFunction.setF(Functions.f2);
                    }
                    try
                    {
                        Console.WriteLine("Корінь: " + getRootFunction(myFunction));
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Bye , have a nice day!");
                Console.ReadKey();
            }

        }
    }
}