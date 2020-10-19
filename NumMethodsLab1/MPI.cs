using System;
using System.Collections.Generic;
using System.Text;

namespace NumMethodsLab1
{
    class MPI
    {
        static double lambda;
        static double q;
        static double a;
        static double b;
        static Func<double, double> f;
        static Func<double, double> df;
        static double eps = Math.Pow(10, -7);

        static double phi(double x)
        {
            return x - lambda * f(x);
        }

        static void findLambda()
        {
            if (Auxiliary.isMonotonous(df, a, b))
            {
                double alpha = Math.Min(df(a), df(b));
                double gamma = Math.Max(df(a), df(b));
                lambda = 2 / (alpha + gamma);
                q = (gamma - alpha) / (gamma + alpha);
            }
        }

        static bool stopCriteria(double _a, double _b)
        {
            return Math.Abs(_a - _b) <= Math.Abs((1 - q) * eps / q);
        }
        public static double getRoot(MyFunction func)
        {
            f = func.getF();
            df = Derivative.get(f);
            a = func.getA();
            b = func.getB();
            eps = func.getEps();

            int i = 1;

            if (!Auxiliary.isMonotonous(f, a, b))
            {
                throw new System.InvalidOperationException("Функція не строго монотонна на цьому проміжку. Виберіть інший проміжок.");

            }
            else if (!Auxiliary.isRootOnRange(a, b, f))
            {
                throw new System.InvalidOperationException("Функція не має коренів на цьому проміжку. Виберіть інший проміжок.");
            }

            findLambda();
            Console.WriteLine("Лямбда: " + lambda);

            while (true)
            {
                b = phi(a);
                if (stopCriteria(a, b))
                    break;
                a = b;
                Console.WriteLine("№" + i + "   Наближене значення: " + a);
                i++;
            }
            return (a + b) / 2;
        }

    }
}
