using PASaveEditor;

namespace FileModel {
    internal class Contraband : Node {
        public ContrabandPrisoners Prisoners;


        public Contraband(string label)
            : base(label) {}


        public override Node CreateNode(string label) {
            if (label.Equals("Prisoners")) {
                DoNotInline = true;
                Prisoners = new ContrabandPrisoners(label);
                return Prisoners;
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteNode(Prisoners);
        }
    }
}
