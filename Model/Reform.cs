namespace PASaveEditor.Model {
    class Reform : Node {
        public ReformPrograms Programs;

        public Reform(string label)
            : base(label) {}


        public override Node CreateNode(string label) {
            if (label.Equals("Programs")) {
                Programs = new ReformPrograms(label);
                return Programs;
            } else {
                return base.CreateNode(label);
            }
        }
    }
}
