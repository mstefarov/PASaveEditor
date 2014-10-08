using PASaveEditor;

namespace FileModel {
    class Victory : Node {
        public VictoryLog Log;

        public Victory(string label)
            : base(label, true) {}


        public override Node CreateNode(string label) {
            if ("Log".Equals(label)) {
                return (Log = new VictoryLog(label));
            }else  {
                return base.CreateNode(label);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteNode(Log);
        }
    }
}
