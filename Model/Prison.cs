using System;
using System.Collections.Generic;

namespace PASaveEditor.Model {
    internal class Prison : Node {
        public string Version;
        public double TimeIndex;
        public bool EnabledMisconduct;
        public bool EnabledDecay;
        public bool EnabledVisibility;
        public bool UnlimitedFunds;

        public Contraband Contraband;
        public Finance Finance;
        public Informants Informants;
        public Misconduct Misconduct;
        public Dictionary<Id, ObjectBase> Objects;
        public Penalties Penalties;
        public Dictionary<Id, Prisoner> Prisoners;
        public Reform Reform;
        public Dictionary<string, Research> Research;
        public Tunnels Tunnels;
        public Victory Victory;


        public override void ReadKey(string key, string value) {
            switch (key) {
                case "Version":
                    Version = value;
                    break;
                case "TimeIndex":
                    TimeIndex = Double.Parse(value);
                    break;
                case "EnabledMisconduct":
                    EnabledMisconduct = Boolean.Parse(value);
                    break;
                case "EnabledDecay":
                    EnabledDecay = Boolean.Parse(value);
                    break;
                case "EnabledVisibility":
                    EnabledVisibility = Boolean.Parse(value);
                    break;
                case "UnlimitedFunds":
                    UnlimitedFunds = Boolean.Parse(value);
                    break;
                default:
                    base.ReadKey(key, value);
                    break;
            }
        }


        public override Node CreateNode(string label) {
            switch (label) {
                case "Contraband":
                    Contraband = new Contraband();
                    return Contraband;

                case "Finance":
                    Finance = new Finance();
                    return Finance;

                case "Informants":
                    Informants = new Informants();
                    return Informants;

                default:
                    return base.CreateNode(label);
            }
        }
    }
}