using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public class Operation : IExpressionTree, IOperation
    {
        public Operation(IExpressionTree.Operations  operation, IExpressionTree first , IExpressionTree second = null) 
        {
            First = first;
            Second =  (second is null) ? new NullElement() : second;
            Operator = operation;
        }
        public IExpressionTree.Operations Operator { get; set; }
        public IExpressionTree First { get; set; }
        public IExpressionTree Second { get; set; }

    }
}
