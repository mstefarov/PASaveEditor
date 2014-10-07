using System;

namespace PASaveEditor.Model {
    internal class TunnelCell : Node {
        public Pos Pos;
        public bool IsEntrance;

        public TunnelCell(string label) : base(label) {
            Pos = Pos.ParsePos(label);
        }


        public override void ReadKey(string key, string value) {
            if ("Entrance".Equals(key)) {
                IsEntrance = Boolean.Parse(value);
            } else {
                base.ReadKey(key, value);
            }
        }
    }
}