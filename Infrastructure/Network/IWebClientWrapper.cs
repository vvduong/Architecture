using System;
using System.Collections.Generic;
using System.Linq;

namespace Architecture.Infrastructure.Network
{
    public interface IWebClientWrapper
    {
        void Post(string address, string json);
    }
}