﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace DomainEventTest
{

    public static class DomainEvents
    {
        [ThreadStatic]
        private static List<Delegate> actions;

        public static IContainer Container { get; set; }

        public static void Register<T>(Action<T> callback) where T : IDomainEvent
        {
            if (actions == null)
            {
                actions = new List<Delegate>();
            }
            actions.Add(callback);
        }

        public static void ClearCallbacks()
        {
            actions = null;
        }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if(Container!=null)
                foreach (var handler in Container.Resolve<IEnumerable<IHandles<T>>>())
                {
                    handler.Handle(args);
                }

            if(actions!=null)
                foreach (var action in actions)
                {
                    if (action is Action<T>) ((Action<T>)action)(args);
                }
        }
    }
}
