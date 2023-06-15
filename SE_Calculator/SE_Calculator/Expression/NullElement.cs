using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public class NullElement:IExpressionTree
    {
        public IExpressionTree First { get; set; }
        public IExpressionTree Second { get; set; }
    }
}
