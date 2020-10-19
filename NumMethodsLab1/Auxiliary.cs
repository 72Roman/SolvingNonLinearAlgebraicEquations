using System;
using System.Collections.Generic;
using System.Text;

namespace NumMethodsLab1
{
    class Auxiliary
    {
        public static bool isRootOnRange(double a, double b, Func<double, double> f)
        {
            return f(a) * f(b) < 0;
        }

        public static bool simplifiedStopCriteria(double a, double b, Func<double, double> f, double eps)
        {
            return Math.Abs(a - b) < eps;
        }
        public static bool isMonotonous(Func<double, double> f, double a, double b)
        {
            double step = 0.0001;
            bool grows = f(a) < f(a + step);
            for (double x = a; x < b; x += step)
            {
                if (f(x) < f(x + step) != grows)
                    return false;
            }
            return true;
        }
    }
}
