using System;
using System.Linq.Expressions;

namespace SE_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ComponentBuilder componentBuilder = new ComponentBuilder();
            componentBuilder
                .AddItem(IBuilder.ConcreteDecorators.Arithmetic)
                .AddItem(IBuilder.ConcreteDecorators.Bit)
                .AddItem(IBuilder.ConcreteDecorators.Degree)
                .AddItem(IBuilder.ConcreteDecorators.Trigonometry);
            Computer computer = componentBuilder.Build() as Computer;

            IExpressionTree tree =
                new Operation(IExpressionTree.Operations.Multiplication,
                new Operation(IExpressionTree.Operations.Cos, new Constant(Math.PI)),
                new Operation(IExpressionTree.Operations.Addition, new Constant(3), new Constant(6)));

            IExpressionTree tree2 =
                new Operation(IExpressionTree.Operations.Multiplication,
                    new Operation(IExpressionTree.Operations.Cos, new Constant(Math.PI)),
                    new Operation(IExpressionTree.Operations.Multiplication, 
                        new Operation(IExpressionTree.Operations.Sin, new Constant(Math.PI / 6)),
                        new Constant(10)));
            IExpressionTree tree3 = new Operation(IExpressionTree.Operations.Factorial, new Constant(5));
            IExpressionTree tree4 = new Operation(IExpressionTree.Operations.Disjuncture, new Constant(5), new Constant(10));

            var result = computer.Compute(tree);

            Console.WriteLine("Выражение передано в виде дерева выражения:");
            if (result is NullElement) 
                Console.WriteLine("Ошибка!");
            else if (result is Constant)
                Console.WriteLine((result as Constant).Const.ToString());

            result = computer.Compute("Multiplication(Addition(5;2);5)");

            Console.WriteLine("Выражение передано в виде строки:");
            if (result is NullElement)
                Console.WriteLine("Ошибка!");
            else if (result is Constant)
                Console.WriteLine((result as Constant).Const.ToString());
        }
    }
}
