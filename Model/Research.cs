using System.Collections.Generic;

namespace PASaveEditor.Model {
    class Research : Node {
        public readonly List<ResearchItem> Items = new List<ResearchItem>(); 

        public Research(string label)
            : base(label) {}


        public override Node CreateNode(string label) {
            var newItem = new ResearchItem(label);
            Items.Add(newItem);
            return newItem;
        }
    }
}
