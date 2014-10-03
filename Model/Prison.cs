using System.Collections.Generic;

namespace PASaveEditor.Model {
    class Prison : Node {
        public string Version;
        public int TimeIndex;
        public bool EnabledMisconduct;
        public bool EnabledDecay;
        public bool EnabledVisibility;
        public bool UnlimitedFunds;
        
        public Contraband Contraband;
        public Finance Finance;
        public Dictionary<Id, Informant> Informants;
        public Misconduct Misconduct;
        public Dictionary<Id,ObjectBase> Objects;
        public Penalties Penalties;
        public Dictionary<Id,Prisoner> Prisoners;
        public Reform Reform;
        public Dictionary<string,Research> Research;
        public Tunnels Tunnels;
        public Victory Victory;
    }
}
