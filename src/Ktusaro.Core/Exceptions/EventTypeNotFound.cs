using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ktusaro.Core.Exceptions
{
    public class EventTypeNotFound : Exception
    {
        public EventTypeNotFound() : base("Event type was not found")
        {
        }
    }
}
