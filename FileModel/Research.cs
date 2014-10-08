using System.Collections.Generic;
using PASaveEditor;

namespace FileModel {
    class Research : Node {
        public readonly List<ResearchItem> Items = new List<ResearchItem>(); 

        public Research(string label)
            : base(label) {}


        public override Node CreateNode(string label) {
            var newItem = new ResearchItem(label);
            Items.Add(newItem);
            return newItem;
        }


        public override void WriteStuff(Writer writer) {
            foreach (ResearchItem item in Items) {
                writer.WriteNode(item);
            }
        }
    }
}
