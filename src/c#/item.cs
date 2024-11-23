using System;
using System.Xml.Serialization;

namespace SpacePeace;

[Serializable]
[XmlRoot("Item", Namespace ="http://www.univ-grenoble-alpes.fr/Item" )]
public class item
{
    [XmlAttribute("Id")] public Id _id { init; get; }

    public class Id
    {
        [XmlAttribute("id")] public int _id { init; get; }

    }
    
}