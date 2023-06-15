using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public class DecoratorTrigonometry : IComputer
    {
        public const IExpressionTree.Operations _operations =
                IExpressionTree.Operations.Sin |
                IExpressionTree.Operations.Cos |
                IExpressionTree.Operations.Tan |
                IExpressionTree.Operations.Ctan;
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
                if (!(expressionTree.Second is NullElement)) return new NullElement();
                switch ((expressionTree as Operation).Operator)
                {
                    case IExpressionTree.Operations.Sin:
                        expressionTree = Sin(expressionTree.First as Constant);
                        break;
                    case IExpressionTree.Operations.Cos:
                        expressionTree = Cos(expressionTree.First as Constant);
                        break;
                    case IExpressionTree.Operations.Subtraction:
                        expressionTree = Tan(expressionTree.First as Constant);
                        break;
                    case IExpressionTree.Operations.Mod:
                        expressionTree = Ctan(expressionTree.First as Constant);
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

        public Constant Sin(Constant left) => new Constant(Math.Sin(left.Const));
        public Constant Cos(Constant left) => new Constant(Math.Cos(left.Const));
        public Constant Tan(Constant left) => new Constant(Math.Tan(left.Const));
        public Constant Ctan(Constant left) => new Constant(1.0 / Math.Tan(left.Const));
    }
}
