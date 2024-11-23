using System;
using System.Xml;
using System.Xml.Serialization;
[Serializable]

namespace SpacePeace;
[Serializable]
[XmlRoot("Level", Namespace ="http://www.univ-grenoble-alpes.fr/Level" )]
public class level
{
    private Tile[] _tileMap;
    public string tiles;

    public level(Tile[] tileMap)
    {
        _tileMap = tileMap;
    }
    
    public void Initialize() {
        _tileMap = new Tile[];
        
    }
    
    [XmlAttribute("nom")] public Nom _Nom { init; get; }
    [XmlAttribute("Id")] public Id _Id { init; get; }
    [XmlAttribute("CheminBackgroung")] public CheminBackgroung _CheminBackground { init; get; }

    public class Nom
    {
        [XmlAttribute("NomPropre")] public NomPropre _NomP { init; get; }

        public class NomPropre
        {
            [XmlAttribute("nom")] public String _nom { init; get; }

        }
    }

    public class Id
    {
        [XmlAttribute("id")] public int _id { init; get; }
    }
    
    
    public class CheminBackgroung
    {
        [XmlAttribute("cheminBackground")] public String _CB { init; get; }
   
    }
    

}