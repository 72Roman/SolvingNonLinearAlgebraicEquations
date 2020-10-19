using System;
using System.Collections.Generic;
using System.Text;

namespace NumMethodsLab1
{
    class HordMethod
    {
        public static double getRoot(MyFunction func)
        {
            double a = func.getA();
            double b = func.getB();
            double eps = func.getEps();

            Func<double, double> f = func.getF();
            Func<double, double> df = Derivative.get(f);

            double c = 0;

            int i = 1;
            Console.WriteLine("Початковий проміжок [ " + a + " ; " + b + " ].");

            if (!Auxiliary.isMonotonous(f, a, b))
            {
                throw new System.InvalidOperationException("Функція не строго монотонна на цьому проміжку. Виберіть інший проміжок.");

            }
            else if (!Auxiliary.isRootOnRange(a, b, f))
            {
                throw new System.InvalidOperationException("Функція не має коренів на цьому проміжку. Виберіть інший проміжок.");
            }

            do
            {
                c = a - (f(a) * (b - a)) / (f(b) - f(a));

                if (Math.Abs(f(c)) < eps)
                {
                    return c;
                }
                else if (f(c) * f(a) < 0)
                {
                    b = c;
                }
                else if (f(c) * f(b) < 0)
                {
                    a = c;
                }

                Console.WriteLine("№" + i + "   Наближене значення: " + c);
                i++;

            }
            while (!Auxiliary.simplifiedStopCriteria(a, b, f, eps));

            return (a + b) / 2;

        }

    }
}
