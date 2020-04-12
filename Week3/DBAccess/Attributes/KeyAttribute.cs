using System;

namespace DBAccess.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class KeyAttribute : Attribute
    {
        public string Name { get; private set; }

        public KeyAttribute(string name)
        {
            Name = name;
        }
    }
}