using System.Collections.Generic;
using PASaveEditor;

namespace FileModel {
    internal class ContrabandPrisoners : Node {
        public readonly Dictionary<int, Node> Prisoners = new Dictionary<int, Node>();


        public ContrabandPrisoners(string label)
            : base(label) { }


        public override Node CreateNode(string label) {
            if (Parser.IsId(label)) {
                DoNotInline = true;
                int prisonerId = Parser.ParseId(label);
                var item = new Node(label);
                Prisoners.Add(prisonerId, item);
                return item;

            } else {
                return base.CreateNode(label);
            }
        }


        public override void ReadKey(string key, string value) {
            if (!"Size".Equals(key)) {
                // do not store size -- it will be counted and written at save-time
                base.ReadKey(key, value);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteProperty("Size", Prisoners.Count);
            foreach (var prisoner in Prisoners) {
                writer.WriteNode(prisoner.Value);
            }
        }
    }
}