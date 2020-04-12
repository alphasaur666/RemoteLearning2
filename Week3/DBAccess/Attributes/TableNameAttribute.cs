using System;

namespace DBAccess.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class TableNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public TableNameAttribute(string name)
        {
            Name = name;
        }
    }
}