using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEventTest
{
    public class Customer
    {
        public void DoSomething()
        {
            //do some work before 

            DomainEvents.Raise(new CustomerBecamePreferred()
                                   {
                                       Customer = this
                                   });
        }

        public string Name { get; set; }
    }
}
