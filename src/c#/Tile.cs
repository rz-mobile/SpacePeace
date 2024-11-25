using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Vector2 = System.Numerics.Vector2;

namespace SpacePeace;
[Serializable]
[XmlRoot("Tile", Namespace ="http://www.univ-grenoble-alpes.fr/Tile" )]
public class Tile
{
    public Vector2 _position;
    public Rectangle bounds;
    private Sprite _texture;

    public Tile(int x, int y, String value,Texture2D texture)
    {
        int id =  Int32.Parse(value);
        //Console.WriteLine(id);
        _position = new Vector2((int)(x*3.5), (int)(y*8.375));
        bounds = new Rectangle(); 
        bounds.X = (id % 16)*16;
        bounds.Y = id - bounds.X;
        bounds.Width = 16;
        bounds.Height = 16;
        _texture = new Sprite(texture,_position,100);
        Console.WriteLine(_position + " : " + value);
        
    }
    public void Initialize() {
        
    }

    public void Update(GameTime gameTime)
    {
        //Console.WriteLine(_position +" " + gameTime.ElapsedGameTime.Milliseconds);
        _texture.setPosition(_position);
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
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
        }
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
