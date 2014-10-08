using System;
using PASaveEditor;

namespace FileModel {
    internal class Misconduct : Node {
        public MisconductReports Reports;
        public double TimeWithoutIncident;


        public Misconduct(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if ("TimeWithoutIncident".Equals(key)) {
                TimeWithoutIncident = Double.Parse(value);
            } else {
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label) {
            if ("MisconductReports".Equals(label)) {
                Reports = new MisconductReports(label);
                return Reports;
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteNode(Reports);
        }
    }
}