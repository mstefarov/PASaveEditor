using System.Collections.Generic;
using System.IO;

namespace PASaveEditor.Model {
    class Node {
        public virtual void ReadKey(string key, string value) {
            AddProperty(key, value);
        }


        public virtual Node CreateNode(string label) {
            Node newNode = new Node();
            newNode.Label = label;
            AddNode(label, newNode);
            return newNode;
        }

        public string Label;
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

        public void AddNode(string key,Node value) {
            if (Nodes == null) {
                Nodes = new Dictionary<string, List<Node>>();
            }
            List<Node> list;
            if (!Nodes.TryGetValue(key, out list)) {
                list = new List<Node>();
                Nodes.Add(key,list);
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


        public override string ToString() {
            return "Node(" + Label + ")";
        }
    }
}
