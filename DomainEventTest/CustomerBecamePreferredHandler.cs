using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEventTest
{
    public class CustomerBecamePreferredHandler : IHandles<CustomerBecamePreferred>
    {
        public void Handle(CustomerBecamePreferred args)
        {
            // send email
            Console.WriteLine("send email to " + args.Customer.Name);
        }
    }
}
