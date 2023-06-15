using System;
using System.Collections.Generic;
using System.Text;

namespace SE_CopyService
{
    public class Printer:AbstractPrinter
    {

        private int _index;
        private PrintFormats _printFormat;
        private Colors _color;

        public int Index { get => _index; private set { _index = value; } }
        public PrintFormats Format { get => _printFormat; private set { _printFormat = value; } }
        public Colors Col { get => _color; private set { _color = value; } }

        public Printer(PrintFormats formats = PrintFormats.A4, Colors col = Colors.BW )
        {
            Index = _counter++;
            Format = formats;
            Col = col;
        }
    }
}
