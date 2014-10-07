using System.Collections.Generic;

namespace PASaveEditor.Model {
    internal class Contraband : Node {
        public readonly Dictionary<int, Node> Prisoners = new Dictionary<int, Node>();


        public Contraband(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if (!"Size".Equals(key)) {
                // do not store size -- it will be counted and written at save-time
                base.ReadKey(key,value);
            }
        }

        public override Node CreateNode(string label) {
            if (Parser.IsId(label)) {
                int prisonerId = Parser.ParseId(label);
                var item = new Node(label);
                Prisoners.Add(prisonerId, item);
                return item;

            } else {
                return base.CreateNode(label);
            }
        }
    }
}