using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAuto
{
    using Autofac;

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyCar>().As<ICar>();
            builder.RegisterType<OtherCar>().As<ICar>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var service = scope.Resolve<IEnumerable<ICar>>();
                foreach (var car in service)
                {
                    car.Run();
                }
            }
        }
    }

    internal class OtherCar : ICar
    {
        public void Run()
        {
            Console.WriteLine("OtherCar");
        }
    }

    internal class MyCar : ICar
    {
        public void Run()
        {
            Console.WriteLine("MyCar");
        }
    }

    internal interface ICar
    {
        void Run();
    }
}
