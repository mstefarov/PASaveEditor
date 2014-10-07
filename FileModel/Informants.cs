using System.Collections.Generic;
using PASaveEditor;

namespace FileModel {
    class Informants : Node {
        public readonly List<Informant> Prisoners = new List<Informant>();


        public Informants(string label)
            : base(label) {}


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

            } else if (Parser.IsId(label)) {
                var informant = new Informant(label);
                Prisoners.Add(informant);
                return informant;

            } else {
                return base.CreateNode(label);
            }
        }
    }
}
