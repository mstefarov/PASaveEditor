using System.Collections.Generic;
using PASaveEditor;

namespace FileModel {
    internal class MisconductReports : Node {
        public readonly Dictionary<int, Node> Reports = new Dictionary<int, Node>();


        public MisconductReports(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if (!"Size".Equals(key)) {
                base.ReadKey(key, value);
            }
        }

        public override Node CreateNode(string label) {
            if (Parser.IsId(label)) {
                var report = new Node(label);
                int prisonerId = Parser.ParseId(label);
                Reports.Add(prisonerId, report);
                return report;
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteProperty("Size",Reports.Count);
            foreach (Node report in Reports.Values) {
                writer.WriteNode(report);
            }
        }
    }
}