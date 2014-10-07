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
        public Objects Objects;
        public Penalties Penalties;
        public Reform Reform;
        public Dictionary<string, Research> Research;
        public Tunnels Tunnels;
        public Victory Victory;


        public Prison() : base("Prison") {}


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
                    Contraband = new Contraband(label);
                    return Contraband;

                case "Finance":
                    Finance = new Finance(label);
                    return Finance;

                case "Informants":
                    Informants = new Informants(label);
                    return Informants;

                case "Misconduct":
                    Misconduct = new Misconduct(label);
                    return Misconduct;

                case "Objects":
                    Objects = new Objects(label);
                    return Objects;

                case "Penalties":
                    Penalties = new Penalties(label);
                    return Penalties;

                default:
                    return base.CreateNode(label);
            }
        }
    }
}