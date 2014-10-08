using PASaveEditor;

namespace FileModel {
    internal class Reform : Node {
        public ReformPrograms Programs;


        public Reform(string label)
            : base(label, true) {}


        public override Node CreateNode(string label) {
            if (label.Equals("Programs")) {
                return (Programs = new ReformPrograms(label));
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteNode(Programs);
        }
    }
}