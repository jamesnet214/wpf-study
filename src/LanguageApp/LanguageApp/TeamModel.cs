using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace LanguageApp
{
    public class TeamModel
    {
        public string Id { get; private set; }
        public object Parent { get; private set; }
        public string Name { get; private set; }
        public List<TeamModel> Children { get; set; }
        internal TeamModel DataGen(string id, object parent, string name)
        {
            Id = id;
            Parent = parent;
            Name = name;
            Children = new();
            return this;
        }
    }
}