using PASaveEditor;

namespace FileModel {
    internal class Informants : Node {
        public Informants2 Informants2;

        public Informants(string label)
            : base(label) {}


        public override Node CreateNode(string label) {
            if ("Informants".Equals(label)) {
                DoNotInline = true;
                // There are two nested "Informants" tags -- we can flatten the hierarchy a bit.
                Informants2 = new Informants2(label);
                return Informants2;
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteNode(Informants2);
        }
    }
}
