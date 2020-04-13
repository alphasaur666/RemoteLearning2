using System;

namespace DBAccess.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class PrimaryKeyAttribute : Attribute
    {
    }
}