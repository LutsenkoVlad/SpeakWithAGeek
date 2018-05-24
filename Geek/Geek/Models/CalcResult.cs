using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geek.Models
{
    public class CalcResult
    {
        public Guid Id { get; set; }

        public double Result { get; set; }

        public CalcResult(double result)
        {
            Id = Guid.NewGuid();
            Result = result;
        }
    }
}
