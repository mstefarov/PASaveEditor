using System;

namespace FileModel {
    internal class PrisonerBio : Node {
        public string Forname, Surname;
        public int Sentence;
        public double Served;


        public PrisonerBio(string label)
            : base(label) {}


        public override void ReadKey(string key, string value) {
            switch (key) {
                case "Forname":
                    Forname = value;
                    break;
                case "Surname":
                    Surname = value;
                    break;
                case "Sentence":
                    Sentence = Int32.Parse(value);
                    break;
                case "Served":
                    Served = Double.Parse(value);
                    break;
                default:
                    base.ReadKey(key, value);
                    break;
            }
        }
    }
}