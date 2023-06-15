using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE_Calculator
{
    public class Adapter : IExpressionTree
    {

        private IExpressionTree _tree = new NullElement();
        private string _strTree;

        public IExpressionTree First { get; set; }
        public IExpressionTree Second { get; set; }
        public Adapter(string str)
        {
            _strTree = str;

            str = str.Replace("(", " ( ");
            str = str.Replace(")", " ) ");
            str = str.Replace(";", " ; ");

            List<string> tokens = (str.Split(new char[] { ' ' })).ToList<string>();
            tokens.RemoveAt(tokens.Count - 1);
            while (tokens.Remove("")) ;
            _tree = Insert(tokens); 
        }

        public IExpressionTree Insert(List<string> tokens)
        {
            int count = -1;
            for (int i = 0, x = -1; i != -1; count++ )
            {
                i = tokens.IndexOf("(", x + 1);
                x = i; 
            }
            if (count <= 1) 
                return GetExpressionTree(tokens[0], GetExpressionTree (tokens[2]), GetExpressionTree(tokens[4]));
            string[] newTokensF = new string[tokens.Count - 2];
            string[] newTokensS = new string[tokens.Count - 4];
            tokens.CopyTo(2, newTokensF, 0, tokens.Count - 2);
            tokens.CopyTo(4, newTokensS, 0, tokens.Count - 4);
            return GetExpressionTree(tokens[0], Insert(newTokensF.ToList()), Insert(newTokensS.ToList()));

        }

        private IExpressionTree GetExpressionTree(string str, IExpressionTree first = null, IExpressionTree second = null)
        {
            double constant;
            if (Double.TryParse(str, out constant)) return new Constant(constant);
            IExpressionTree result = new NullElement();
            switch (str)
            {
                case "Addition":
                    result = new Operation(IExpressionTree.Operations.Addition, first, second);
                    break;
                case "Multiplication":
                    result = new Operation(IExpressionTree.Operations.Multiplication, first, second);
                    break;
                case "Subtraction":
                    result = new Operation(IExpressionTree.Operations.Subtraction, first, second);
                    break;
                case "Division":
                    result = new Operation(IExpressionTree.Operations.Division, first, second);
                    break;
                case "Mod":
                    result = new Operation(IExpressionTree.Operations.Mod, first, second);
                    break;
                case "Sin":
                    result = new Operation(IExpressionTree.Operations.Sin, first, second);
                    break;
                case "Cos":
                    result = new Operation(IExpressionTree.Operations.Cos, first, second);
                    break;
                case "Tan":
                    result = new Operation(IExpressionTree.Operations.Tan, first, second);
                    break;
                case "Ctan":
                    result = new Operation(IExpressionTree.Operations.Ctan, first, second);
                    break;
                case "Conditions":
                    result = new Operation(IExpressionTree.Operations.Conditions, first, second);
                    break;
                case "Disjuncture":
                    result = new Operation(IExpressionTree.Operations.Disjuncture, first, second);
                    break;
                case "Webb":
                    result = new Operation(IExpressionTree.Operations.Webb, first, second);
                    break;
                case "SchaefferStroke":
                    result = new Operation(IExpressionTree.Operations.SchaefferStroke, first, second);
                    break;
                case "PierceArrow":
                    result = new Operation(IExpressionTree.Operations.PierceArrow, first, second);
                    break;
                case "Inversion":
                    result = new Operation(IExpressionTree.Operations.Inversion, first, second);
                    break;
                case "Degree":
                    result = new Operation(IExpressionTree.Operations.Degree, first, second);
                    break;
                case "Factorial":
                    result = new Operation(IExpressionTree.Operations.Factorial, first, second);
                    break;
                case "Module":
                    result = new Operation(IExpressionTree.Operations.Module, first, second);
                    break;
            }
            return result;
        }

        public IExpressionTree GetTree() => _tree;

    }
}
