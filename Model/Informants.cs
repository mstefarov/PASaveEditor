using System.Collections.Generic;

namespace PASaveEditor.Model {
    class Informants : Node {
        public readonly List<Informant> Prisoners = new List<Informant>();

        public override void ReadKey(string key, string value) {
            if (!"Size".Equals(key)) {
                // do not store size -- it will be counted and written at save-time
                base.ReadKey(key,value);
            }
        }

        public override Node CreateNode(string label) {
            if ("Informants".Equals(label)) {
                // There are two nested "Informants" tags -- we can flatten the hierarchy a bit.
                return this;

            } else if (Id.IsI(label)) {
                Informant informant = new Informant();
                Prisoners.Add(informant);
                return informant;

            } else {
                return base.CreateNode(label);
            }
        }
    }
}
