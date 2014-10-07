using System.Collections.Generic;

namespace FileModel {
    class Tunnels : Node {
        public readonly List<TunnelCell> TunnelCells = new List<TunnelCell>(); 
        public Tunnels(string label)
            : base(label) {}


        public override Node CreateNode(string label) {
            if (Pos.IsPos(label)) {
                var cell = new TunnelCell(label);
                TunnelCells.Add(cell);
                return cell;
            } else {
                return base.CreateNode(label);
            }
        }
    }
}
