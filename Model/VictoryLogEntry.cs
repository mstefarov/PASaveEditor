namespace PASaveEditor.Model {
    internal class VictoryLogEntry : Node {
        public string Type;
        public Id PrisonerId;


        public VictoryLogEntry(string label)
            : base(label) {}
    }
}