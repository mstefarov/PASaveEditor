using PASaveEditor;

namespace FileModel {
    internal class Penalties : Node {
        public Penalties2 Penalties2;

        public Penalties(string label)
            : base(label) {}


        public override Node CreateNode(string label) {
            if (label.Equals("Penalties")) {
                return (Penalties2 = new Penalties2(label));
            } else {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteNode(Penalties2);
        }
    }
}