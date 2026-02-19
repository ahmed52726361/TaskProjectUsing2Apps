using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace businessLayerOfTasks
{
    public static class clsXmlPersistence
    {
        public static void SaveToFile(string filePath, List<clsTask> tasks)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<clsTask>));
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, tasks);
            }
        }

        public static List<clsTask> LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return new List<clsTask>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<clsTask>));
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                return (List<clsTask>)serializer.Deserialize(stream);
            }
        }
    }
}