using System;
using System.Xml;

namespace WebSite.Comman
{
    public class XMLUtil
    {
        private XMLUtil()
        {
        }

        public static XmlNode AppendElement(XmlNode node, string newElementName)
        {
            return AppendElement(node, newElementName, null);
        }

        public static XmlNode AppendElement(XmlNode node, string newElementName, string innerValue)
        {
            XmlNode node2;
            if (node is XmlDocument)
            {
                node2 = node.AppendChild(((XmlDocument)node).CreateElement(newElementName));
            }
            else
            {
                node2 = node.AppendChild(node.OwnerDocument.CreateElement(newElementName));
            }
            if (innerValue != null)
            {
                node2.AppendChild(node.OwnerDocument.CreateTextNode(innerValue));
            }
            return node2;
        }

        public static XmlAttribute CreateAttribute(XmlDocument xmlDocument, string name, string value)
        {
            XmlAttribute attribute = xmlDocument.CreateAttribute(name);
            attribute.Value = value;
            return attribute;
        }

        public static string GetNodeValue(XmlDocument xml, string nodeName)
        {
            XmlNodeList elementsByTagName = xml.GetElementsByTagName(nodeName);
            if (elementsByTagName.Count > 0)
            {
                return elementsByTagName[0].InnerText.Trim();
            }
            return "";
        }

        public static string GetNodeValue(XmlElement xml, string nodeName)
        {
            XmlNodeList elementsByTagName = xml.GetElementsByTagName(nodeName);
            if (elementsByTagName.Count > 0)
            {
                return elementsByTagName[0].InnerText.Trim();
            }
            return "";
        }

        public static void SetAttribute(XmlNode node, string attributeName, string attributeValue)
        {
            if (node.Attributes[attributeName] != null)
            {
                node.Attributes[attributeName].Value = attributeValue;
            }
            else
            {
                node.Attributes.Append(CreateAttribute(node.OwnerDocument, attributeName, attributeValue));
            }
        }

        public static void SetNodeValue(XmlDocument xml, string nodeName, bool value)
        {
            XmlNodeList elementsByTagName = xml.GetElementsByTagName(nodeName);
            if (elementsByTagName.Count > 0)
            {
                elementsByTagName[0].InnerText = value.ToString();
            }
        }

        public static void SetNodeValue(XmlDocument xml, string nodeName, decimal value)
        {
            XmlNodeList elementsByTagName = xml.GetElementsByTagName(nodeName);
            if (elementsByTagName.Count > 0)
            {
                elementsByTagName[0].InnerText = value.ToString();
            }
        }

        public static void SetNodeValue(XmlDocument xml, string nodeName, int value)
        {
            XmlNodeList elementsByTagName = xml.GetElementsByTagName(nodeName);
            if (elementsByTagName.Count > 0)
            {
                elementsByTagName[0].InnerText = value.ToString();
            }
        }

        public static void SetNodeValue(XmlDocument xml, string nodeName, float value)
        {
            XmlNodeList elementsByTagName = xml.GetElementsByTagName(nodeName);
            if (elementsByTagName.Count > 0)
            {
                elementsByTagName[0].InnerText = value.ToString();
            }
        }

        public static void SetNodeValue(XmlDocument xml, string nodeName, string value)
        {
            XmlNodeList elementsByTagName = xml.GetElementsByTagName(nodeName);
            if (elementsByTagName.Count > 0)
            {
                elementsByTagName[0].InnerText = value;
            }
        }

        public static void SetNodeValue(XmlElement xml, string nodeName, string value)
        {
            XmlNodeList elementsByTagName = xml.GetElementsByTagName(nodeName);
            if (elementsByTagName.Count > 0)
            {
                elementsByTagName[0].InnerText = value;
            }
        }
    }
}