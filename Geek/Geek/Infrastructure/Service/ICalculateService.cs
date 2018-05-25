using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geek.Infrastructure.Service
{
    public interface ICalculateService
    {
        double Add(double a, double b);

        double Sub(double a, double b);

        double Mul(double a, double b);

        double Div(double a, double b);

        double Exp(double number);
    }
}
