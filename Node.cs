using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PASaveEditor.Model {
    internal class Node {
        public Node(string label) {
            Label = label;
        }

        public string Label;
        public Dictionary<string, List<string>> Properties;
        public Dictionary<string, List<Node>> Nodes;

        public virtual void ReadKey(string key, string value) {
            PushProperty(key, value);
        }


        public virtual Node CreateNode(string label) {
            Node newNode = new Node(label);
            newNode.Label = label;
            PushNode(label, newNode);
            return newNode;
        }


        public virtual void FinishedReadingNode(Node node) {
        }


        public void PushProperty(string key,string value) {
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

        public void PushNode(string key,Node value) {
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


        public Node PopNode(string key) {
            List<Node> list = Nodes[key];
            Node nodeToRemove = list[list.Count - 1];
            list.RemoveAt(list.Count-1);
            if (list.Count == 0) {
                Nodes[key] = null;
            }
            return nodeToRemove;
        }


        public string PopProperty(string key) {
            List<string> list = Properties[key];
            string valueToRemove = list[list.Count - 1];
            list.RemoveAt(list.Count-1);
            if (list.Count == 0) {
                Nodes[key] = null;
            }
            return valueToRemove;
        }


        public void ReparseProperties(Node other) {
            foreach (var property in other.ListProperties()) {
                PushProperty(property.Key,property.Value);
            }
        }



        public IEnumerable<KeyValuePair<string, string>> ListProperties() {
            return Properties.SelectMany(
                propList => propList.Value,
                (propList, propValue) => new KeyValuePair<string, string>(propList.Key, propValue));
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
