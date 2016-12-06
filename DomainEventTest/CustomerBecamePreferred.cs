using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEventTest
{
    public class CustomerBecamePreferred : IDomainEvent
    {
        public Customer Customer { get; set; }
    }
}
