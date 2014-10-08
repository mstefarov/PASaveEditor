using System;
using System.Linq;

namespace PASaveEditor.FileModel {
    internal class Prison : Node {
        public string Version;
        public double TimeIndex;
        public bool EnabledMisconduct;
        public bool FailureConditions;
        public bool EnabledVisibility;
        public bool EnabledDecay;
        public bool UnlimitedFunds;
        public bool EnabledIntake;

        public WrapperNode<ContrabandPrisoners> Contraband;
        public Finance Finance;
        public WrapperNode<Informants> Informants;
        public Misconduct Misconduct;
        public Objects Objects;
        public WrapperNode<Penalties> Penalties;
        public Reform Reform;
        public Research Research;
        public Tunnels Tunnels;
        public WrapperNode<VictoryLog> Victory;


        public Prison()
            : base("Prison", true) {}


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
                case "FailureConditions":
                    FailureConditions = Boolean.Parse(value);
                    break;
                case "EnabledVisibility":
                    EnabledVisibility = Boolean.Parse(value);
                    break;
                case "EnabledDecay":
                    EnabledDecay = Boolean.Parse(value);
                    break;
                case "UnlimitedFunds":
                    UnlimitedFunds = Boolean.Parse(value);
                    break;
                case "EnabledIntake":
                    EnabledIntake = Boolean.Parse(value);
                    break;
                default:
                    base.ReadKey(key, value);
                    break;
            }
        }


        public override Node CreateNode(string label) {
            switch (label) {
                case "Contraband":
                    Contraband = new WrapperNode<ContrabandPrisoners>(label, "Prisoners", l => new ContrabandPrisoners(l));
                    return Contraband;

                case "Finance":
                    Finance = new Finance(label);
                    return Finance;

                case "Informants":
                    Informants = new WrapperNode<Informants>(label, "Informants", l => new Informants(l));
                    return Informants;

                case "Misconduct":
                    Misconduct = new Misconduct(label);
                    return Misconduct;

                case "Objects":
                    Objects = new Objects(label);
                    return Objects;

                case "Penalties":
                    Penalties = new WrapperNode<Penalties>(label, "Penalties", l => new Penalties(l));
                    return Penalties;

                case "Reform":
                    Reform = new Reform(label);
                    return Reform;

                case "Research":
                    Research = new Research(label);
                    return Research;

                case "Tunnels":
                    Tunnels = new Tunnels(label);
                    return Tunnels;

                case "Victory":
                    Victory = new WrapperNode<VictoryLog>(label, "Log", l => new VictoryLog(l));
                    return Victory;

                default:
                    return base.CreateNode(label);
            }
        }


        public override void WriteProperties(Writer writer) {
            // we do not write Version here -- Writer takes care of it
            writer.WriteProperty("TimeIndex", TimeIndex);
            if (EnabledMisconduct) {
                writer.WriteProperty("EnabledMisconduct", EnabledMisconduct);
            }
            if (FailureConditions) {
                writer.WriteProperty("FailureConditions", FailureConditions);
            }
            if (EnabledVisibility) {
                writer.WriteProperty("EnabledVisibility", EnabledVisibility);
            } else {
                Nodes.Remove("Visibility");
            }
            if (EnabledDecay) {
                writer.WriteProperty("EnabledDecay",EnabledDecay);
            } else {
                // erase all dirt
                var cellNodes = Nodes["Cells"][0].ListNodes().ToList();
                cellNodes.ForEach(node => node.Properties.Remove("Con"));
            }
            if (UnlimitedFunds) {
                writer.WriteProperty("UnlimitedFunds", UnlimitedFunds);
            }
            if (EnabledIntake) {
                writer.WriteProperty("EnabledIntake", EnabledIntake);
            }
        }


        public override void WriteNodes(Writer writer) {
            writer.WriteNode(Objects);
            writer.WriteNode(Finance);
            writer.WriteNode(Research);
            writer.WriteNode(Penalties);
            writer.WriteNode(Misconduct);
            writer.WriteNode(Contraband);
            writer.WriteNode(Tunnels);
            writer.WriteNode(Reform);
            writer.WriteNode(Victory);
            writer.WriteNode(Informants);
        }
    }
}