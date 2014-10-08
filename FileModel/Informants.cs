using PASaveEditor;

namespace FileModel {
    internal class Informants : Node {
        public Informants2 Informants2;

        public Informants(string label)
            : base(label, true) {}


        public override Node CreateNode(string label) {
            if ("Informants".Equals(label)) {
                return (Informants2 = new Informants2(label));
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteNode(Informants2);
        }
    }
}
