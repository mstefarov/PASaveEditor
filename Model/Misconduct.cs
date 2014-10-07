using System;
using System.Collections.Generic;

namespace PASaveEditor.Model {
    internal class Misconduct : Node {
        public double TimeWithoutIncident;
        public readonly Dictionary<int, Node> MisconductReports = new Dictionary<int, Node>();


        public Misconduct(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if ("TimeWithoutIncident".Equals(key)) {
                TimeWithoutIncident = Double.Parse(value);
            } else if (!"Size".Equals(key)) {
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label) {
            if ("MisconductReports".Equals(label)) {
                return this;
            } else if (Id.IsI(label)) {
                Node report = new Node(label);
                int prisonerId = Id.ParseI(label);
                MisconductReports.Add(prisonerId, report);
                return report;
            } else {
                return base.CreateNode(label);
            }
        }
    }
}