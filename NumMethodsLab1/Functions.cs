using System;
using System.Collections.Generic;
using System.Text;

namespace NumMethodsLab1
{
    static class Functions
    {

        public static double f1(double x)
        {
            return 5 + Math.Pow(x, 7) * Math.Sin(x)
                - Math.Pow(x, 13) * Math.Cos(x) * Math.Sqrt(Math.PI - Math.Cos(Math.Pow(x, 3)));
        }

        public static double f2(double x)
        {
            return Math.Pow(x, 2) + Math.PI * Math.Log10(13 * Math.PI) - 5 * Math.PI * Math.Sin(x) - 2 * x;
        }

        public static double lobachevsky(double x)
        {
            double[] koefs = LobachevskyiMethod.koefs;

            double sum = 0;
            for (int i = 0; i < koefs.Length; i++)
            {
                sum += koefs[i] * Math.Pow(x, koefs.Length - i - 1);
            }
            return sum;
        }
    }
}
