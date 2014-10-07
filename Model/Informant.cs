using System;

namespace PASaveEditor.Model {
    class Informant : Node {
        public int PrisonerId;
        public double Coverage;
        public double Suspicion;
        public double HighestSuspicion;


        public Informant(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            switch (key) {
                case "Prisoner.i":
                    PrisonerId = Int32.Parse(value);
                    break;
                case "Coverage":
                    Coverage = Double.Parse(value);
                    break;
                case "Suspicion":
                    Suspicion = Double.Parse(value);
                    break;
                case "HighestSuspicion":
                    HighestSuspicion = Double.Parse(value);
                    break;
                default:
                    base.ReadKey(key, value);
                    break;
            }
        }
    }
}
