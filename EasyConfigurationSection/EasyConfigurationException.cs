using System;

namespace EasyConfigurationSection
{
    public class EasyConfigurationException : Exception
    {
        public EasyConfigurationException(Exception inner)
            : base("Failed to load configuration section", inner) { }
    }
}