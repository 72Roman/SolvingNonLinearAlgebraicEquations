using System;
using System.Collections.Generic;
using System.Text;

namespace NumMethodsLab1
{
    public class MyFunction
    {
        private double a;
        private double b;
        public double eps = Math.Pow(10, -7);

        private Func<double, double> f;
        private Func<double, double> df;

        public MyFunction(double a, double b, Func<double, double> f)
        {
            this.a = a;
            this.b = b;
            this.f = f;
            this.df = Derivative.get(f);
        }
        public MyFunction(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public MyFunction(double a, double b, Func<double, double> f, double eps)
        {
            this.a = a;
            this.b = b;
            this.f = f;
            this.df = Derivative.get(f);
            this.eps = eps;
        }


        public double getA() { return this.a; }
        public double getB() { return this.b; }
        public Func<double, double> getF() { return this.f; }
        public double getEps() { return this.eps; }

        public void setEps(double eps) { this.eps = eps; }
        public void setF(Func<double, double> f) { this.f = f; }
    }
}
