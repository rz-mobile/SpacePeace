using System;
using System.Numerics;
using System.Xml.Serialization;

namespace SpacePeace;
[Serializable]
[XmlRoot("Tile", Namespace ="http://www.univ-grenoble-alpes.fr/Tile" )]
public class Tile
{
    private Sprite[] sprites;
    private GameObject hitbox;
    public Vector2 position
    {
        get => position;
        private set => position = value;
        
    }

    public Tile(int x, int y, Sprite[] sprites)
    {
        
    }
    public void Initialize() {
        
    }
    
    [XmlAttribute("Identifiant")] public Identifiant _identifiant { init; get; }
    [XmlAttribute("Solide")] public Solide _solide { init; get; }
    
    public class Identifiant
    {
        [XmlAttribute("Id")] public Id _id { init; get; }

        public class Id
        {
            [XmlAttribute("id")] public int _id { init; get; }

        }
    }
    
    public class Solide
    {
        [XmlAttribute("solide")] public Boolean _solide { init; get; }

    }
}
