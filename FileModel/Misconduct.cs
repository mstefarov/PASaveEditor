using System;
using System.Collections.Generic;
using PASaveEditor;

namespace FileModel {
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
            } else if (Parser.IsId(label)) {
                var report = new Node(label);
                int prisonerId = Parser.ParseId(label);
                MisconductReports.Add(prisonerId, report);
                return report;
            } else {
                return base.CreateNode(label);
            }
        }
    }
}