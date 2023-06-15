using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public class Constant: IExpressionTree
    {
        public Constant(double constant) => Const = constant;
        public double Const { get; set; }
        public IExpressionTree First { get; set; }
        public IExpressionTree Second { get; set; }

        public Constant ReturnResult() => this;
    }
}
