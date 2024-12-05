using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpacePeace;
[Serializable]
[XmlRoot("Tile", Namespace ="http://www.univ-grenoble-alpes.fr/Tile" )]
public class Tile
{
    
    public Vector2 _offset;
    public Vector2 _position;
    public Rectangle bounds;
    private Sprite _sprite;

    public Tile(int x, int y, String value,int size)
    {
        int id =  Int32.Parse(value);
        //Console.WriteLine(id);
        _position = new Vector2(x, y);
        //_position = new Vector2((int)(x), (int)(y));
        bounds = new Rectangle(); 
        bounds.X = (id % 16)*16 -16;
        bounds.Y = id;
        //bounds.Width = 16;
        //bounds.Height = 10;
        bounds.Width = 16;
        bounds.Height = 10;
        _sprite = new Sprite("map",_position,size);
        //Console.WriteLine(_position + " : " + value);
        
    }
    public void Initialize() {
        
    }

    public void setOffset(Vector2 offset)
    {
        _position = _position + offset;
    }

    public void Update(GameTime gameTime)
    {
        
        //Console.WriteLine(_position +" " + gameTime.ElapsedGameTime.Milliseconds);
        _sprite.setPosition(_position);
        /*if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            _position.X += 10;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            _position.X -= 10;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            _position.Y += 10;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            _position.Y -= 10;
        }*/
        //Console.WriteLine(_sprite._position);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch,bounds);
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
