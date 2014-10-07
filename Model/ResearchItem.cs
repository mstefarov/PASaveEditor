using System;

namespace PASaveEditor.Model {
    internal class ResearchItem : Node {
        public string Name;
        public double Progress;


        public ResearchItem(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if ("Name".Equals(key)) {
                Name = value;
            }else if ("Progress".Equals(key)) {
                Progress = Double.Parse(value);
            } else {
                base.ReadKey(key, value);
            }
        }
    }
}