using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public class DecoratorBit : IComputer
    {
        public const IExpressionTree.Operations _operations =
                IExpressionTree.Operations.Conditions |
                IExpressionTree.Operations.Disjuncture |
                IExpressionTree.Operations.Webb |
                IExpressionTree.Operations.SchaefferStroke |
                IExpressionTree.Operations.PierceArrow |
                IExpressionTree.Operations.Inversion;
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
                    case IExpressionTree.Operations.Conditions:
                        if (expressionTree.Second is NullElement) return new NullElement();
                        expressionTree = Conditions(expressionTree.First as Constant, expressionTree.Second as Constant);
                        break;
                    case IExpressionTree.Operations.Disjuncture:
                        if (expressionTree.Second is NullElement) return new NullElement();
                        expressionTree = Disjuncture(expressionTree.First as Constant, expressionTree.Second as Constant);
                        break;
                    case IExpressionTree.Operations.Webb:
                        if (expressionTree.Second is NullElement) return new NullElement();
                        expressionTree = Webb(expressionTree.First as Constant, expressionTree.Second as Constant);
                        break;
                    case IExpressionTree.Operations.SchaefferStroke:
                        expressionTree = SchaefferStroke(expressionTree.First as Constant, expressionTree.Second as Constant);
                        if (expressionTree.Second is NullElement) return new NullElement();
                        break;
                    case IExpressionTree.Operations.PierceArrow:
                        expressionTree = PierceArrow(expressionTree.First as Constant, expressionTree.Second as Constant);
                        if (expressionTree.Second is NullElement) return new NullElement();
                        break;
                    case IExpressionTree.Operations.Inversion:
                        if (!(expressionTree.Second is NullElement)) return new NullElement();
                        expressionTree = Inversion(expressionTree.First as Constant);
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

        public Constant Conditions(Constant left, Constant right)
    => new Constant((int)left.Const & (int)right.Const);
        public Constant Disjuncture(Constant left, Constant right)
    => new Constant((int)left.Const | (int)right.Const);
        public Constant Webb(Constant left, Constant right)
    => new Constant(~((int)left.Const | (int)right.Const));
        public Constant SchaefferStroke(Constant left, Constant right)
    => new Constant(~((int)left.Const & (int)right.Const));
        public Constant PierceArrow(Constant left, Constant right)
    => new Constant(~((int)left.Const | (int)right.Const));
        public Constant Inversion(Constant left)
    => new Constant(~(int)left.Const);
    }
}
