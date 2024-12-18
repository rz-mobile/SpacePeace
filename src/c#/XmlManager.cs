using System;
using System.IO;
using System.Xml.Serialization;

namespace SpacePeace;

public class XmlManager<T>
{
    public T Load(string path)
    {
        T _instance;
        using (TextReader reader = new StreamReader(path))
        {
            var xml = new XmlSerializer(typeof(T));
            _instance = (T)xml.Deserialize(reader);
        }

        return _instance;
    }

    public void Save(string path, object obj)
    {
        using (TextWriter writer = new StreamWriter(path))
        {
            var xml = new XmlSerializer(typeof(T));
            xml.Serialize(writer,obj);
        }
    }
    
    public void Save(string path, object obj,XmlSerializerNamespaces ns)
    {
        Console.WriteLine(path);
        using (TextWriter writer = new StreamWriter(path))
        {
            var xml = new XmlSerializer(typeof(T));
            xml.Serialize(writer,obj,ns);
        }
    }
}