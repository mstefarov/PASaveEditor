using System;
using System.Collections.Generic;

namespace PASaveEditor.Model {
    class Penalties: Node {
        public readonly Dictionary<Id,List<Penalty>> PenaltyList = new Dictionary<Id, List<Penalty>>();


        public Penalties(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if(!key.Equals("Size")){
                base.ReadKey(key, value);
            }
        }


        public override Node CreateNode(string label) {
            if (label.Equals("Penalties")) {
                return this;
            }else if (Id.IsI(label)) {
                return new Penalty(label);
            } else {
                return base.CreateNode(label);
            }
        }
    }
}
