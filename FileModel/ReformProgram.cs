using PASaveEditor;

namespace FileModel {
    internal class ReformProgram : Node {
        public ReformStudents Students;


        public ReformProgram(string label)
            : base(label, true) {}


        public override Node CreateNode(string label) {
            if ("Students".Equals(label)) {
                return (Students = new ReformStudents(label));
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteNode(Students);
        }
    }
}