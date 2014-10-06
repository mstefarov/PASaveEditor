namespace PASaveEditor.Model {
    internal class ContrabandItem : Node {
        public ContrabandItem(int id) {
            PrisonerId = id;
        }

        public readonly int PrisonerId;
    }
}