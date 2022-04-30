using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SE_ServiceCentre
{
    internal class AbstractHandler : IHandler
    {
        public List<IDetail> Details { get; protected set; }
        private bool _isBusy = false;
        public bool IsBusy { get => _isBusy; set => _isBusy = value; }
        private IHandler _nextHandler;
        private IHandler _firstHandler;
        public IHandler FirstHandler { get => _firstHandler; set => _firstHandler = value; }
        public IHandler NextHandler { get => _nextHandler; set => _nextHandler = value; }
        public IHandler SetNext(IHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public void GetFirstHandler()
        {
            if (FirstHandler == null) FirstHandler = this;
            for (var i = NextHandler; i != null; i = NextHandler.NextHandler)
            {
                i.FirstHandler = this;
            }

        }

        public virtual object Handle(object request)
        {
            if (NextHandler != null)
            {
                return NextHandler.Handle(request);
            }

            else
            {
                Thread.Sleep(1);
                return FirstHandler.Handle(request);
            }

        }
    }

}
