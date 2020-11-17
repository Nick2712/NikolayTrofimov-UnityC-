using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;


namespace NikolayTrofimov_Game
{
    public class XMLData : IData<SaveData>
    {
        public void Save(SaveData player, string path = "")
        {
            var xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement("Player");
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Name");
            element.SetAttribute("value", player.Name);
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PosX");
            element.SetAttribute("value", player.Position.X.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PosY");
            element.SetAttribute("value", player.Position.Y.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PosZ");
            element.SetAttribute("value", player.Position.Z.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("IsEnable");
            element.SetAttribute("value", player.IsEnabled.ToString());
            rootNode.AppendChild(element);

            XmlNode userNode = xmlDoc.CreateElement("Info");
            var attribute = xmlDoc.CreateAttribute("Unity");
            attribute.Value = Application.unityVersion;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "System Language: " + Application.systemLanguage;
            rootNode.AppendChild(userNode);

            xmlDoc.Save(path);
        }

        public SaveData Load(string path = "")
        {
            var result = new SaveData();
            if (!File.Exists(path)) return result;
            using (var reader = new XmlTextReader(path))
            {
                while(reader.Read())
                {
                    var key = "Name";
                    if(reader.IsStartElement(key))
                    {
                        result.Name = reader.GetAttribute("value");
                    }

                    key = "PosX";
                    if (reader.IsStartElement(key))
                    {
                        if (float.TryParse(reader.GetAttribute("value"), out float valueX)) 
                            result.Position.X = valueX;
                    }

                    key = "PosY";
                    if (reader.IsStartElement(key))
                    {
                        if (float.TryParse(reader.GetAttribute("value"), out float valueY)) 
                            result.Position.Y = valueY;
                    }

                    key = "PosZ";
                    if (reader.IsStartElement(key))
                    {
                        if (float.TryParse(reader.GetAttribute("value"), out float valueZ))
                            result.Position.Z = valueZ;
                    }

                    key = "IsEnable";
                    if (reader.IsStartElement(key))
                    {
                        if (bool.TryParse(reader.GetAttribute("value"), out bool valueIsEnabled))
                            result.IsEnabled = valueIsEnabled;
                    }
                }
            }

            return result;
        }
    }
}