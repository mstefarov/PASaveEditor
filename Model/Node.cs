using System.Collections.Generic;
using System.IO;

namespace PASaveEditor.Model {
    class Node {
        public string NodeType;
        public string NodeLabel;
        public Dictionary<string, List<string>> Properties;
        public Dictionary<string, List<Node>> Nodes;

        public void AddProperty(string key,string value) {
            if (Properties == null) {
                Properties = new Dictionary<string, List<string>>();
            }
            List<string> list;
            if (!Properties.TryGetValue(key, out list)) {
                list = new List<string>();
                Properties.Add(key,list);
            }
            list.Add(value);
        }

        
        public void WriteProperties(StringWriter writer, int indent) {
            foreach (var property in Properties) {
                for (int i = 0; i < indent; i++) {
                    writer.Write("    ");
                }
                writer.Write(property.Key);
                writer.Write(" ");
                writer.Write(property.Value);
                writer.Write("\n");
            }
        }

        public void WritePropertiesInline(StringWriter writer) {
            foreach (var property in Properties) {
                writer.Write(property.Key);
                writer.Write(" ");
                writer.Write(property.Value);
                writer.Write("  ");
            }
        }
    }
}
