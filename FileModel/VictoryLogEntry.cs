using System;

namespace FileModel {
    internal class VictoryLogEntry : Node {
        public string Type;
        public int PrisonerId;


        public VictoryLogEntry(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if ("Type".Equals(key)) {
                Type = value;
            }else if ("PrisonerId.i".Equals(key)) {
                PrisonerId = Int32.Parse(value);
            } else {
                base.ReadKey(key, value);
            }
        }
    }
}