using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEventTest
{
    public class CustomerChargeHandler : IHandles<CustomerBecamePreferred>
    {
        public void Handle(CustomerBecamePreferred args)
        {
            Console.WriteLine(args.Customer.Name + " recharge $500");
        }
    }
}
