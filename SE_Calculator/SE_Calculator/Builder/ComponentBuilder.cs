using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public class ComponentBuilder: IBuilder
    {
        private List<IBuilder.ConcreteDecorators> _chain = new List<IBuilder.ConcreteDecorators>();
        public IComputer Build()
        {
            IComputer result =  new Computer();
            result.Main = result as Computer;
            IComputer last = result;
            foreach (var i in _chain)
            {
                switch (i)
                {
                    case IBuilder.ConcreteDecorators.Computer:
                        if (result is Computer) break;
                        last.Injected = new Computer();
                        last.Main = result as Computer;
                        last = last.Injected;
                        break;
                    case IBuilder.ConcreteDecorators.Arithmetic:
                        last.Injected = new DecoratorArithmetic();
                        last.Main = result as Computer;
                        last = last.Injected;
                        break;
                    case IBuilder.ConcreteDecorators.Bit:
                        last.Injected = new DecoratorBit();
                        last.Main = result as Computer;
                        last = last.Injected;
                        break;
                    case IBuilder.ConcreteDecorators.Degree:
                        last.Injected = new DecoratorDegree();
                        last.Main = result as Computer;
                        last = last.Injected;
                        break;
                    case IBuilder.ConcreteDecorators.Trigonometry:
                        last.Injected = new DecoratorTrigonometry();
                        last.Main = result as Computer;
                        last = last.Injected;
                        break;
                }
            }
            
            return result;
        }
        public IBuilder AddItem(IBuilder.ConcreteDecorators decorator)
        {
            _chain.Add(decorator);
            return this;
        }

    }
}
