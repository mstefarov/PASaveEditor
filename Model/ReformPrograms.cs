using System.Collections.Generic;

namespace PASaveEditor.Model {
    internal class ReformPrograms : Node {
        public readonly List<ReformProgram> Programs = new List<ReformProgram>();

        public ReformPrograms(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            if (!key.Equals("Size")) {
                base.ReadKey(key, value);
            }
        }

        public override Node CreateNode(string label) {
            if (Parser.IsId(label)) {
                var program = new ReformProgram(label);
                Programs.Add(program);
                return program;
            } else {
                return base.CreateNode(label);
            }
        }
    }
}