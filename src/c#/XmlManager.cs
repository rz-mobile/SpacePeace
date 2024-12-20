using System;
using System.IO;
using System.Xml.Serialization;

namespace SpacePeace;

public class XmlManager<T>
{
    //prends une chaine de caractere et renvoie un T, deserialise un T a partir du fichier xml designe par le chemin
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
    //prends une chaine de caractere et un objet et ne renvoie rien, serialise un objet dans le fichier xml designe par le chemin    
    public void Save(string path, object obj)
    {
        using (TextWriter writer = new StreamWriter(path))
        {
            var xml = new XmlSerializer(typeof(T));
            xml.Serialize(writer,obj);
        }
    }
    //prends une chaine de caractere ,un objet et un XmlSerializeNamespaces et ne renvoie rien, serialise un objet dans le fichier xml designe par le chemin selon son namespace  
    public void Save(string path, object obj,XmlSerializerNamespaces ns)
    {
        using (TextWriter writer = new StreamWriter(path))
        {
            var xml = new XmlSerializer(typeof(T));
            xml.Serialize(writer,obj,ns);
        }
    }
}