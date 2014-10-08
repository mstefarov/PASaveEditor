using System.Collections.Generic;
using PASaveEditor;

namespace FileModel {
    internal class Informants2 : Node {
        public readonly List<Informant> Prisoners = new List<Informant>();


        public Informants2(string label)
            : base(label, true) {}


        public override void ReadKey(string key, string value) {
            if (!"Size".Equals(key)) {
                // do not store size -- it will be counted and written at save-time
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label) {
            if (Parser.IsId(label)) {
                var informant = new Informant(label);
                Prisoners.Add(informant);
                return informant;

            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteProperties(Writer writer) {
            writer.WriteProperty("Size", Prisoners.Count);
        }


        public override void WriteNodes(Writer writer) {
            foreach (Informant informant in Prisoners) {
                writer.WriteNode(informant);
            }
        }
    }
}