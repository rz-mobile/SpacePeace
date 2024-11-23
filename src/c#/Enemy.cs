using System;
using System.Xml.Serialization;

namespace SpacePeace;

[Serializable]
[XmlRoot("Enemy", Namespace ="http://www.univ-grenoble-alpes.fr/Enemy" )]

public class Enemy
{
    [XmlAttribute("Pv")] public Int _Pv { init; get; }
    [XmlAttribute("Id")] public Int _Id { init; get; }
    [XmlAttribute("Degats")] public Int _Degats { init; get; }
    
    public class Int
    {
        [XmlAttribute("id")] public int _id { init; get; }
    }
    
    
}