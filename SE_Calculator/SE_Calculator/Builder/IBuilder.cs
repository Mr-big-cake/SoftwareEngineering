using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public interface IBuilder
    {
        public enum ConcreteDecorators
            { 
            Computer,
            Arithmetic,
            Bit,
            Degree,
            Trigonometry
        }

        public IComputer Build();
        public IBuilder AddItem(ConcreteDecorators decorator);
    }
}
