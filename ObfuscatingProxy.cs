using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace testingTest
{
    public class ObfuscatingProxy<T> : DispatchProxy
    {
        private T _target;
        private string _propertyToObfuscate;

        public void Initialize(T target, string propertyToObfuscate)
        {
            _target = target;
            _propertyToObfuscate = propertyToObfuscate;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            if (targetMethod.Name == $"get_{_propertyToObfuscate}")
            {
                throw new InvalidOperationException($"Access to the property '{_propertyToObfuscate}' is not allowed.");
            }
            return targetMethod.Invoke(_target, args);
        }
    }
}
