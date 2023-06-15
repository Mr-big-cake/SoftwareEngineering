using System;
using System.Collections.Generic;
using System.Text;

namespace SE_Calculator
{
    public class FMContext:IFMContext
    {
        public ComponentBuilder FacroryMethod()
        {
            return new ComponentBuilder();
        }
    }
}
