using PASaveEditor;

namespace FileModel {
    class Prisoner : ObjectBase {
        public string Category;
        public PrisonerBio Bio;


        public Prisoner(ObjectBase baseObj)
            : base(baseObj.Label) {
            Id = baseObj.Id;
            Type = baseObj.Type;
            
            ReparseProperties(baseObj);
            CopyNodes(baseObj);
            Bio = (PrisonerBio)PopNode("Bio");
        }


        public override void ReadKey(string key, string value) {
            if ("Category".Equals(key)) {
                Category = value;
            } else {
                base.ReadKey(key, value);
            }
        }


        public override void WriteStuff(Writer writer) {
            writer.WriteProperty("Category",Category);
            writer.WriteNode(Bio);
        }
    }
}
