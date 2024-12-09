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
    [XmlElement("height")]public int _height;
    [XmlElement("width")]public int _width;
    private Color _color = Color.White;
    public Rectangle _rect { get => new Rectangle((int) _position.X - _width/2, (int) _position.Y - _height/2,_width, _height); }

    public Sprite(string texture, Vector2 position, int size) {
        _textureName = texture;
        _texture = Utils._textures[_textureName];
        _position = position; 
        _height = size;
        _width = size;
    }
    
    public Sprite(string texture, Vector2 position, int height , int width) {
        _textureName = texture;
        _texture = Utils._textures[_textureName];
        _position = position; 
        _height = height;
        _width = width;
    }

    public Sprite()
    {
        _height = 50;
        _width = 100;
        _position = new Vector2(300, 300);
        _texture = Utils._textures["ship2"];
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
