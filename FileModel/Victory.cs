using System.Collections.Generic;
using PASaveEditor;

namespace FileModel {
    class Victory : Node {
        public readonly List<VictoryLogEntry> Log = new List<VictoryLogEntry>();


        public Victory(string label)
            : base(label) {}


        public override Node CreateNode(string label) {
            if ("Log".Equals(label)) {
                return this;
            }else if (Parser.IsId(label)) {
                var entry = new VictoryLogEntry(label);
                Log.Add(entry);
                return entry;
            } else {
                return base.CreateNode(label);
            }
        }
    }
}
