using System;
using System.Collections.Generic;
using System.Text;

namespace NumMethodsLab1
{
    public class CombinedMethod
    {
        public static double getRoot(MyFunction func)
        {
            double a = func.getA();
            double b = func.getB();
            double eps = func.getEps();

            Func<double, double> f = func.getF();
            Func<double, double> df = Derivative.get(f);
            Func<double, double> d2f = Derivative.get(df);

            int i = 1;

            if (!Auxiliary.isMonotonous(f, a, b))
            {
                throw new System.InvalidOperationException("Функція не строго монотонна на цьому проміжку. Виберіть інший проміжок.");

            }
            else if (!Auxiliary.isRootOnRange(a, b, f))
            {
                throw new System.InvalidOperationException("Функція не має коренів на цьому проміжку. Виберіть інший проміжок.");
            }

            Console.WriteLine("Початковий проміжок [ " + a + " ; " + b + " ].");

            bool a_by_hord = false;

            if (f(a) * d2f(a) < 0)
                a_by_hord = true;

            do
            {
                if (a_by_hord)
                {
                    Console.WriteLine("a хордами");

                    a = a - f(a) * (b - a) / (f(b) - f(a));
                    b = b - f(b) / df(b);
                }
                else
                {

                    a = a - f(a) / df(a);
                    b = a - f(a) * (b - a) / (f(b) - f(a));
                }

                Console.WriteLine("№" + i + "   Наближене значення: (a)  " + a);
                Console.WriteLine("№" + i + "   Наближене значення: (b)  " + b);
                i++;

            }
            while (!Auxiliary.simplifiedStopCriteria(a, b, f, eps));

            return (a + b) / 2;
        }

    }
}
