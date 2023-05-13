using System;
using System.Xml.Linq;

namespace LanguageApp
{
    public class ThemeModel
    {
        public string Code { get; private set; }
        public string Name { get; private set; }

        internal ThemeModel DataGen(string code, string name)
        {
            Code = code;
            Name = name;
            return this;
        }
    }
}