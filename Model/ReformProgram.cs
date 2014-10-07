using System.Collections.Generic;

namespace PASaveEditor.Model {
    internal class ReformProgram : Node {
        public HashSet<Id> Students;


        public ReformProgram(string label)
            : base(label) {}
    }
}