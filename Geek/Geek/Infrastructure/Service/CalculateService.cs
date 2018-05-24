using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geek.Infrastructure.Service
{
    public class CalculateService : ICalculateService
    {
        public double Add(double a, double b) => a + b;

        public double Div(double a, double b) => a / b;

        public double Exp(double number) => Math.Exp(number);

        public double Mul(double a, double b) => a * b;

        public double Sub(double a, double b) => a - b;
    }

    public interface ICalculateService
    {
        double Add(double a, double b);

        double Sub(double a, double b);

        double Mul(double a, double b);

        double Div(double a, double b);

        double Exp(double number);
    }
}
