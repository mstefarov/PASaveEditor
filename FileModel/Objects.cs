using System.Collections.Generic;

namespace FileModel {
    class Objects : Node {
        public readonly Dictionary<int, ObjectBase> OtherObjects = new Dictionary<int, ObjectBase>();
        public readonly Dictionary<int, Prisoner> Prisoners = new Dictionary<int, Prisoner>();


        public Objects(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if (!"Size".Equals(key)) {
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label) {
            var newObj = new ObjectBase(label);
            OtherObjects.Add(newObj.Id,newObj);
            return newObj;
        }


        public override void FinishedReadingNode(Node node) {
            var obj = (ObjectBase)node;
            if ("Prisoner".Equals(obj.Type) ) {
                OtherObjects.Remove(obj.Id);
                var prisoner = new Prisoner(obj);
                Prisoners.Add(prisoner.Id,prisoner);
            }
        }
    }
}
