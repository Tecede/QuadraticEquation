using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadraticEquation
{
    public class Equation
    {
        double a, b, c;
        double d, x1, x2;

        public Equation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        private void DecideD()
        {
            d = b * b - 4 * a * c;
        }

        public double[] Solve()
        {
            DecideD();
            
            if(a == 0)
            {
                double[] answer = new double[1];

                x1 = -c / b;

                x1 = Math.Round(x1, 2);
                answer[0] = x1;

                return answer;
            }
            else
            if (d > 0)
            {
                double[] answer = new double[2];

                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);

                x1 = Math.Round(x1, 2);
                x2 = Math.Round(x2, 2);

                answer[0] = x1;
                answer[1] = x2;

                return answer;
            }
            else
            if (d == 0)
            {
                double[] answer = new double[1];

                x1 = -b / (2 * a);
                x1 = Math.Round(x1, 2);

                answer[0] = x1;

                return answer;
            }

            return null;
        }

        public double GetA()
        {
            return a;
        }
        public double GetB()
        {
            return b;
        }
        public double GetC()
        {
            return c;
        }
        public double GetD()
        {
            return d;
        }
    }
}
