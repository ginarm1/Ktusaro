using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ktusaro.Core.Exceptions
{
    public class EventTypeNotFound : EntityNotFoundException
    {
        public EventTypeNotFound() : base("notFound","Event type was not found")
        {
        }
    }
}
