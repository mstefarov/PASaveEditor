using System;
using System.Collections.Generic;
using System.Linq;
using PASaveEditor;

namespace FileModel {
    class Objects : Node {
        public readonly Dictionary<int, ObjectBase> OtherObjects = new Dictionary<int, ObjectBase>();
        public readonly Dictionary<int, Prisoner> Prisoners = new Dictionary<int, Prisoner>();


        public Objects(string label)
            : base(label, true) {}


        public override void ReadKey(string key, string value) {
            if (!"Size".Equals(key)) {
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label) {
            return new ObjectBase(label, false);
        }


        public override void FinishedReadingNode(Node node) {
            var obj = (ObjectBase)node;
            if ("Prisoner".Equals(obj.Type)) {
                var prisoner = new Prisoner(obj);
                Prisoners.Add(prisoner.Id, prisoner);
            } else {
                OtherObjects.Add(obj.Id, obj);
            }
        }


        public override void WriteProperties(Writer writer) {
            writer.WriteProperty("Size", Math.Max(OtherObjects.Keys.Max(), Prisoners.Keys.Max()) + 1);
        }


        public override void WriteNodes(Writer writer) {
            var mergedObjects = OtherObjects.Values.MergeSorted(Prisoners.Values, (o1, o2) => o1.Id - o2.Id);
            foreach (var obj in mergedObjects) {
                writer.WriteNode(obj);
            }
        }
    }
}
