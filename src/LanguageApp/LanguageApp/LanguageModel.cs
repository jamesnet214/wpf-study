using System;

namespace LanguageApp
{
    public class LanguageModel
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        internal LanguageModel DataGen(string code, string name)
        {
            Code = code;
            Name = name;
            return this;
        }
    }
}