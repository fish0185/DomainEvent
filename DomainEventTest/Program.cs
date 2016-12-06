using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEventTest
{
    using Autofac;

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(CustomerBecamePreferredHandler).Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IHandles<>)))
                .AsImplementedInterfaces();
            var container = builder.Build();
            DomainEvents.Container = container;
            DomainEvents.Register<CustomerBecamePreferred>(c=>Console.WriteLine("sent a emailt to " + c.Customer.Name));
            using (var scope = container.BeginLifetimeScope())
            {
                Customer newCustomer = new Customer
                                           {
                                               Name = "Gary"
                                           };
                newCustomer.DoSomething();
            }
        }
    }
}
