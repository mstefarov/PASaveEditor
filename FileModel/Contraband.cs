using PASaveEditor;

namespace FileModel {
    internal class Contraband : Node {
        public ContrabandPrisoners Prisoners;


        public Contraband(string label)
            : base(label,true) {}


        public override Node CreateNode(string label) {
            if (label.Equals("Prisoners")) {
                return (Prisoners = new ContrabandPrisoners(label));
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteNode(Prisoners);
        }
    }
}
