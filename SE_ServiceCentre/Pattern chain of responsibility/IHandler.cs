using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(object request);
        IHandler NextHandler { get; set; }
        IHandler FirstHandler { get; set; }
        List<IDetail> Details { get; }
    }

}
