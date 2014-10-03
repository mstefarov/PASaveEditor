using System.Collections.Generic;

namespace PASaveEditor.Model {
    class Misconduct : Node {
        public float TimeWithoutIncident;
        public Dictionary<Id, MisconductReport> MisconductReports;
    }
}
