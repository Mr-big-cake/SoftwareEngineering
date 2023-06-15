using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public class DecoratorArithmetic: IComputer
    {
        public const IExpressionTree.Operations _operations =
                IExpressionTree.Operations.Addition |
                IExpressionTree.Operations.Multiplication |
                IExpressionTree.Operations.Subtraction |
                IExpressionTree.Operations.Division |
                IExpressionTree.Operations.Mod;
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
                if (expressionTree.Second is NullElement) return new NullElement();
                switch ((expressionTree as Operation).Operator)
                {
                    case IExpressionTree.Operations.Addition:
                        expressionTree =  Addition(expressionTree.First as Constant, expressionTree.Second as Constant);
                        break;
                    case IExpressionTree.Operations.Multiplication:
                        expressionTree =  Multiplication(expressionTree.First as Constant, expressionTree.Second as Constant);
                        break;
                    case IExpressionTree.Operations.Subtraction:
                        expressionTree =  Subtraction(expressionTree.First as Constant, expressionTree.Second as Constant);
                        break;
                    case IExpressionTree.Operations.Division:
                        expressionTree =  Division(expressionTree.First as Constant, expressionTree.Second as Constant);
                        break;
                    case IExpressionTree.Operations.Mod:
                        expressionTree =  Mod(expressionTree.First as Constant, expressionTree.Second as Constant);
                        break;
                }


                return expressionTree; 
            }
            else if (Injected is null)
                return new NullElement();
            else
                return Injected.Compute(expressionTree);
        }
        public IComputer Injected { get; set;  }
        public IComputer Main { get; set; }

        public Constant Addition(Constant left, Constant right) 
            => new Constant(left.Const + right.Const) ;
        public Constant Multiplication(Constant left, Constant right)
            => new Constant(left.Const * right.Const);
        public Constant Subtraction(Constant left, Constant right)
            => new Constant(left.Const - right.Const);
        public Constant Division(Constant left, Constant right)
            => new Constant(left.Const - right.Const);
        public Constant Mod(Constant left, Constant right)
            => new Constant(left.Const % right.Const);
    }
}
