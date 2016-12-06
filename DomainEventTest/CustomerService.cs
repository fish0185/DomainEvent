using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEventTest
{
    public class CustomerService
    {
        public void Handle()
        {
            Customer customer = new Customer();
            customer.DoSomething();
        }
    }
}
