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
    [XmlElement("height")]public int Height; //longueur sprite sur l'écran
    [XmlElement("width")]public int Width; //largeur sprite sur l'écran
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
        Height = 64;
        Width = 64;
        _texture = Utils._content.Load<Texture2D>(_textureName);
        _textureName = "player";
    }

    public void SetPosition(Vector2 position)
    {
        Position = position;
    }

    public Vector2 getPosition()
    {
        return Position;
    }

    public Texture2D GetTexture()
    {
        return _texture;
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw(_texture,Rect,null,_color);
    }

    public void Draw(SpriteBatch spriteBatch, Rectangle src, SpriteEffects effects)
    {
        spriteBatch.Draw(_texture,Rect,src,_color,0.0f,Vector2.Zero,effects,0 );
    }

    public void Draw(SpriteBatch spriteBatch, Rectangle src, SpriteEffects effects, Color color )
    {
        spriteBatch.Draw(_texture,Rect,src,color,0.0f,Vector2.Zero,effects,0 );
    }

}
