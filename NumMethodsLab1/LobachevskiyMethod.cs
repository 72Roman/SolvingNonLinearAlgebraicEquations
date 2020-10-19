using System;
using System.Collections.Generic;
using System.Text;

namespace NumMethodsLab1
{
    class LobachevskyiMethod
    {
        public static double[] koefs = { -2, 71, -171, -589, 825, 772, -638, -3 };

        const double eps = 0.00000001;
        static double[] normalize(double[] array)
        {
            double[] res = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                res[i] = array[i] / 50;
            }
            return res;
        }
        public static bool stopCriteria(double[] old, double[] _new)
        {
            for (int i = 0; i < old.Length; i++)
            {
                double diff = Math.Abs(Math.Pow(old[i], 2) - _new[i]);
                if (diff > eps)
                {
                    return false;
                }

            }
            return true;

        }

        public static double[] solve()
        {
            double[] a = normalize(koefs);
            double[] b = new double[koefs.Length];

            int n = koefs.Length - 1;
            int p = 0;
            while (!stopCriteria(a, b))
            {
                p++;
                for (int k = 0; k <= n; k++)
                {
                    double sum = 0;
                    for (int j = 1; j <= Math.Min(k, n - k); j++)
                    {
                        sum += Math.Pow(-1, j) * a[k - j] * a[k + j];
                    }
                    b[k] = Math.Pow(a[k], 2) + 2 * sum;
                }
                Array.Copy(normalize(b), a, b.Length);
            }

            double[] res = new double[b.Length - 1];
            double power = Math.Pow(2, -p);

            for (int i = 1; i < b.Length; i++)
            {
                double root = Math.Pow(b[i] / b[i - 1], power);

                if (Math.Abs(Functions.lobachevsky(root)) < 5)
                {
                    res[i - 1] = root;
                }
                else
                {
                    res[i - 1] = -root;
                }
            }

            return res;
        }

        public static double[] getRootsBySomeMethod(double[] roots, Func<MyFunction, double> method, double _eps)
        {
            double[] newRoots = new double[roots.Length];

            double delta = 0.01;
            double a = 0;
            double b = 0;
            Func<double, double> f = Functions.lobachevsky;

            for (int i = 0; i < newRoots.Length; i++)
            {
                a = roots[i] - delta;
                b = roots[i] + delta;

                newRoots[i] = method(new MyFunction(a, b, f, _eps));
            }
            return newRoots;
        }
    }
}
