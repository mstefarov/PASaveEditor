using System;

namespace PASaveEditor.Model {
    internal class ObjectBase : Node {
        public ObjectBase(string label)
            : base(label) {
            Id = Model.Id.ParseI(label);
        }


        public int Id;
        public Pos Pos;
        public string Type;


        public override void ReadKey(string key, string value) {
            switch (key) {
                case "Type":
                    Type = value;
                    break;
                case "Pos.x":
                    Pos.X = Double.Parse(value);
                    break;
                case "Pos.y":
                    Pos.Y = Double.Parse(value);
                    break;
                default:
                    base.ReadKey(key, value);
                    break;
            }
        }


        public override Node CreateNode(string label) {
            if (Type.Equals("Prisoner") && label.Equals("Bio")) {
                return new PrisonerBio(label);
            } else {
                return base.CreateNode(label);
            }
        }
    }
}