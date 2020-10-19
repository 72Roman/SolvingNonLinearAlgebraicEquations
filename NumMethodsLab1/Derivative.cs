using System;
using System.Collections.Generic;
using System.Text;

namespace NumMethodsLab1
{
    class Derivative
    {
        const double step = 0.00001;
        static public Func<double, double> get(Func<double, double> f)
        {
            return (double x) => (f(x) - f(x - step)) / step;
        }
    }
}
