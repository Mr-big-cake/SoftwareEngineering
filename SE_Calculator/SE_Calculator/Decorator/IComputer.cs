using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    // Базовый интерфейс Компонента определяет поведение, которое изменяется декораторами
    public interface IComputer
    {
        public IExpressionTree Compute(IExpressionTree expressionTree);
        public IComputer Injected { get; set; }
        public IComputer Main { get; set; }
    }
}
