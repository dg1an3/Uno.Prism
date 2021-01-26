using System;
using System.Linq;
using DryIoc;
using Prism.Ioc;

namespace Prism.DryIoc.Ioc
{
    public class DryIocContainerExtension : IContainerExtension<IContainer>
    {
        public IContainer Instance { get; }

        public IScopedProvider CurrentScope => throw new NotImplementedException();

        public DryIocContainerExtension(IContainer container)
        {
            Instance = container;
        }

        public void FinalizeExtension() { }

        public IContainerRegistry RegisterInstance(Type type, object instance)
        {
            Instance.UseInstance(type, instance);
            return this;
        }

        public IContainerRegistry RegisterInstance(Type type, object instance, string name)
        {
            Instance.UseInstance(type, instance, serviceKey: name);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to)
        {
            Instance.Register(from, to, Reuse.Singleton);
            return this;
        }

        public IContainerRegistry RegisterSingleton(Type from, Type to, string name)
        {
            Instance.Register(from, to, Reuse.Singleton, serviceKey: name);
            return this;
        }

        public IContainerRegistry Register(Type from, Type to)
        {
            Instance.Register(from, to);
            return this;
        }

        public IContainerRegistry Register(Type from, Type to, string name)
        {
            Instance.Register(from, to, serviceKey: name);
            return this;
        }

        public object Resolve(Type type)
        {
            return Instance.Resolve(type);
        }

        public object Resolve(Type type, string name)
        {
            return Instance.Resolve(type, serviceKey: name);
        }

        public object Resolve(Type type, params (Type Type, object Instance)[] parameters)
        {
            return Instance.Resolve(type, args: parameters.Select(p => p.Instance).ToArray());
        }

        public object Resolve(Type type, string name, params (Type Type, object Instance)[] parameters)
        {
            return Instance.Resolve(type, name, args: parameters.Select(p => p.Instance).ToArray());
        }

        public bool IsRegistered(Type type)
        {
            return Instance.IsRegistered(type);
        }

        public bool IsRegistered(Type type, string name)
        {
            return Instance.IsRegistered(type, name);
        }

        public IScopedProvider CreateScope()
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterSingleton(Type type, Func<object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterSingleton(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterManySingleton(Type type, params Type[] serviceTypes)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry Register(Type type, Func<object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry Register(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterMany(Type type, params Type[] serviceTypes)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterScoped(Type from, Type to)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterScoped(Type type, Func<object> factoryMethod)
        {
            throw new NotImplementedException();
        }

        public IContainerRegistry RegisterScoped(Type type, Func<IContainerProvider, object> factoryMethod)
        {
            throw new NotImplementedException();
        }
    }
}
