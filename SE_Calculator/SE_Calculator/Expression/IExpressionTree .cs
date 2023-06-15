using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public interface IExpressionTree
    {
        [Flags] public enum Operations {
            Addition = 0, Multiplication = 1, Subtraction = 2, Division = 4, Mod = 8,
            Sin = 16, Cos = 32, Tan = 64, Ctan = 128,
            Conditions = 256, Disjuncture= 512, Webb = 1024, SchaefferStroke = 2048, PierceArrow = 4096, Inversion = 8192,
            Degree = 16384, Factorial = 32768, Module = 65536
        }
        public IExpressionTree First {get; set;}
        public IExpressionTree Second {get; set;}
    }
}
