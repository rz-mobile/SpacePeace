using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;
[XmlInclude(typeof(GameObject))]
[XmlRoot("Sprite", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/animatedSprites")]
[Serializable]

public class Sprite
{
    [XmlElement("texture")] public string _textureName;
    private Texture2D _texture;
    protected Vector2 _position;
    [XmlElement("size")] public int _size;
    private Color _color = Color.White;
    public Rectangle _rect { get => new Rectangle((int) _position.X - _size/2, (int) _position.Y - _size/2, _size, _size); }

    public Sprite(string texture, Vector2 position, int size) {
        _textureName = texture;
        _texture = Utils._content.Load<Texture2D>(_textureName);
        _position = position; 
        _size = size;
    }

    public Sprite()
    {
        _size = 50;
        _position = new Vector2(300, 300);
        _texture = Utils._content.Load<Texture2D>(_textureName);
    }

    public void setPosition(Vector2 position)
    {
        _position = position;
    }
    
    public void Update(GameTime gameTime) {
        
    }
    public void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw(   _texture, // Texture2D,
            _rect, // Rectangle destinationRectangle,
            null, // Nullable<Rectangle> sourceRectangle,
            _color); // float layerDepth
    }

    public void Draw(SpriteBatch spriteBatch, Rectangle src)
    {
        spriteBatch.Draw(   _texture, // Texture2D,
            _rect, // Rectangle destinationRectangle,
            src, // Nullable<Rectangle> sourceRectangle,
            _color ); // float layerDepth
    }

}
