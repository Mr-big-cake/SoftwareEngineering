using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE_Calculator
{
    public class DecoratorDegree : IComputer
    {
        public const IExpressionTree.Operations _operations =
            IExpressionTree.Operations.Degree |
            IExpressionTree.Operations.Factorial |
            IExpressionTree.Operations.Module;
        public IExpressionTree Compute(IExpressionTree expressionTree)
        {
            if (expressionTree is NullElement) return new NullElement();
            if (expressionTree.First is Operation)
            {
                expressionTree.First = Main.Compute(expressionTree.First);
            }
            if (expressionTree.Second is Operation)
            {
                expressionTree.Second = Main.Compute(expressionTree.Second);
            }

            if (_operations.HasFlag((expressionTree as Operation).Operator))
            { 
                switch ((expressionTree as Operation).Operator)
                {
                    case IExpressionTree.Operations.Degree:
                        if (expressionTree.Second is NullElement) return new NullElement();
                        expressionTree = Degree(expressionTree.First as Constant, expressionTree.Second as Constant);
                        break;
                    case IExpressionTree.Operations.Factorial:
                        if (!(expressionTree.Second is NullElement)) return new NullElement();
                        expressionTree = Factorial(expressionTree.First as Constant);
                        break;
                    case IExpressionTree.Operations.Module:
                        if (!(expressionTree.Second is NullElement)) return new NullElement();
                        expressionTree = Module(expressionTree.First as Constant);
                        break;
                }


                return expressionTree;
            }
            else if (Injected is null)
                return new NullElement();
            else
                return Injected.Compute(expressionTree);
        }
        public IComputer Injected { get; set; }
        public IComputer Main { get; set; }

        public Constant Degree(Constant left, Constant right)  => new Constant( Math.Pow( left.Const , right.Const));
        public Constant Factorial(Constant left) => new Constant(Enumerable.Range(1, (int)(left.Const))
                     .Aggregate(1, (f, i) => f * i));
        public Constant Module(Constant left) => new Constant(Math.Abs(left.Const));
    }
}
