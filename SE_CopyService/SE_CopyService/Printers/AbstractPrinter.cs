using System;
using System.Collections.Generic;
using System.Text;

namespace SE_CopyService
{
    public abstract class AbstractPrinter
    {
        protected static int _counter = 0;
        public enum Colors
        {
            Color, BW
        }
        public enum PrintFormats
        {
            A4, 
            A3,
            Photo
        }
    }
}
