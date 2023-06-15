using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SE_Calculator
{
    public class Computer : IComputer
    {
        public IExpressionTree Compute(string str)
        {
            Adapter adapter = new Adapter(str);

            return Compute(adapter.GetTree());
        }
        public IExpressionTree Compute(IExpressionTree expressionTree)
        {
            if (expressionTree.First == null) return expressionTree;

            return Injected.Compute(expressionTree);
        }
        public IComputer Injected { get; set; }
        public IComputer Main { get; set; }
    }
}
