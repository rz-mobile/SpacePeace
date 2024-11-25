using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Vector2 = System.Numerics.Vector2;

namespace SpacePeace;
[Serializable]
[XmlRoot("Tile", Namespace ="http://www.univ-grenoble-alpes.fr/Tile" )]
public class Tile
{
    public Vector2 _position;
    public Rectangle bounds;
    private Sprite _texture;

    public Tile(int x, int y, int value,Texture2D texture)
    {
        _position = new Vector2(x, y);
        bounds = new Rectangle(); 
        bounds.X = (value % 16)*16;
        bounds.Y = value - bounds.X;
        bounds.Width = 16;
        bounds.Height = 16;
        _texture = new Sprite(texture,_position,1);
        
    }
    public void Initialize() {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _texture.Draw(spriteBatch,bounds);
    }
    /*
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

    }*/
}
