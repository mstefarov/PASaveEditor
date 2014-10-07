using System.Collections.Generic;

namespace PASaveEditor.Model {
    internal class Penalties : Node {
        public readonly Dictionary<int, List<Penalty>> PenaltyList = new Dictionary<int, List<Penalty>>();


        public Penalties(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if (!key.Equals("Size")) {
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label) {
            if (label.Equals("Penalties")) {
                return this;
            } else if (Parser.IsId(label)) {
                return new Penalty(label);
            } else {
                return base.CreateNode(label);
            }
        }


        public override void FinishedReadingNode(Node node) {
            var penaltyNode = node as Penalty;
            if (penaltyNode != null) {
                List<Penalty> list;
                if (!PenaltyList.TryGetValue(penaltyNode.ObjectId, out list)) {
                    list = new List<Penalty>();
                    PenaltyList.Add(penaltyNode.ObjectId, list);
                }
                list.Add(penaltyNode);
            }
        }
    }
}