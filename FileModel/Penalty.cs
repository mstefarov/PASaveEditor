using System;
using PASaveEditor;

namespace FileModel {
    class Penalty: Node {
        public int ObjectId;

        public Penalty(string label)
            : base(label) {
        }


        public override void ReadKey(string key, string value) {
            if (key.Equals("ObjectId.i")) {
                ObjectId = Int32.Parse(value);
            } else {
                base.ReadKey(key, value);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteProperty("ObjectId.i", ObjectId);
        }
    }
}