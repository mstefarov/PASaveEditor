using System.Collections.Generic;
using System.IO;

namespace PASaveEditor.Model {
    class Contraband : Node {
        public Dictionary<Id, ContrabandItem> Prisoners;
    }
}
