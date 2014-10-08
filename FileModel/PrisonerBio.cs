using System;

namespace PASaveEditor.FileModel {
    internal class PrisonerBio : Node {
        public string Forname, Surname; // TODO: investigate prisoners with blank names
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


        public override void WriteProperties(Writer writer) {
            writer.WriteProperty("Forname", Forname);
            writer.WriteProperty("Surname", Surname);
            writer.WriteProperty("Sentence", Sentence);
            writer.WriteProperty("Served", Served);
        }
    }
}