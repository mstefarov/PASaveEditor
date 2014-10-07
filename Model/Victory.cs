using System.Collections.Generic;

namespace PASaveEditor.Model {
    class Victory : Node {
        public List<VictoryLogEntry> Log;


        public Victory(string label)
            : base(label) {}
    }
}
