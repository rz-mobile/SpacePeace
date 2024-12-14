using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;
[XmlInclude(typeof(GameObject))]
[XmlRoot("Sprite", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/Sprites")]
[Serializable]

public class Sprite
{
    [XmlElement("texture")] public string _textureName;
    private Texture2D _texture;
    protected Vector2 Position;
    [XmlElement("height")]public int Height;
    [XmlElement("width")]public int Width;
    private Color _color = Color.White;
    public Rectangle Rect { get => new Rectangle((int) Position.X - Width/2, (int) Position.Y - Height/2,Width, Height); }

    public Sprite(string texture, Vector2 position, int size) {
        _textureName = texture;
        _texture = Utils._content.Load<Texture2D>(_textureName);
        Position = position; 
        Height = size;
        Width = size;
    }
    
    public Sprite(string texture, Vector2 position, int height , int width) {
        _textureName = texture;
        _texture = Utils._content.Load<Texture2D>(_textureName);
        Position = position; 
        Height = height;
        Width = width;
    }

    public Sprite()
    {
        Position = new Vector2(300, 300);
        Height = 16;
        Width = 16;
        _texture = Utils._textures["player"];
        _textureName = "player";
    }

    public void SetPosition(Vector2 position)
    {
        Position = position;
    }

    public Texture2D GetTexture()
    {
        return _texture;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw(   _texture, // Texture2D,
            Rect, // Rectangle destinationRectangle,
            null, // Nullable<Rectangle> sourceRectangle,
            _color); // float layerDepth
    }

    public void Draw(SpriteBatch spriteBatch, Rectangle src)
    {
        spriteBatch.Draw(   _texture, // Texture2D,
            Rect, // Rectangle destinationRectangle,
            src, // Nullable<Rectangle> sourceRectangle,
            _color ); // float layerDepth
    }

    
}
