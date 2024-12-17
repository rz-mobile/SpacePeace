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
    public Rectangle _bounds;
    private Sprite _sprite;

    public Tile(int x, int y, int value,int size)
    {
        int id =  value;
        _position = new Vector2(x, y);
        _bounds = new Rectangle(); 
        _bounds.X = (id % 16)*16 -16;
        _bounds.Y = id -(id % 16);
        //_bounds.Y = id;
        _bounds.Width = 16;
        _bounds.Height = 16;
        _sprite = new Sprite("mapForest",_position,size);
        
    }
    public void Initialize() {
        
    }

    public void setOffset(Vector2 offset)
    {
        _position = _position + offset;
    }

    public void Update(GameTime gameTime)
    {
        
        _sprite.SetPosition(_position);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch,_bounds, 0);
    }
}
