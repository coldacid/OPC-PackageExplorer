using System;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.Collections;

namespace PackageExplorer.UI.Workbench
{
    public class DefaultEditorCollection
        : StringDictionary, IXmlSerializable
    {
        [Serializable]
        public class Node
        {
            public Node()
            { }

            public Node(string k, string v)
            {
                key = k;
                val = v;
            }

            public string key;
            public string val;
        }

        System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
        {
            XmlSerializer x =
                new XmlSerializer(typeof(System.Collections.ArrayList),
                new System.Type[] { typeof(Node) });

            reader.Read();
            ArrayList list = x.Deserialize(reader) as ArrayList;

            if (list == null)
                return;

            foreach (Node node in list)
            {
                Add(node.key, node.val);
            }
        }

        void IXmlSerializable.WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer x =
                new XmlSerializer(typeof(System.Collections.ArrayList),
                new System.Type[] { typeof(Node) });
            ArrayList list = new ArrayList();
            foreach (string key in this.Keys)
            {
                list.Add(new Node(key, this[key]));
            }
            x.Serialize(writer, list);
        }
    }
}
