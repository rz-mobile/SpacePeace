using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpacePeace;

public class Sprite
{
    
    public string _textureName;
    protected Texture2D _texture;
    public Vector2 _position { get;  set; } 
    public int Height; //longueur sprite sur l'écran
    public int Width; //largeur sprite sur l'écran
    private Color _color = Color.White;
    public Rectangle Rect { get => new Rectangle((int) _position.X - Width/2, (int) _position.Y - Height/2,Width, Height); }

    public Sprite(string texture, Vector2 position, int size) {
        _textureName = texture;
        _texture = Utils._content.Load<Texture2D>(_textureName);
        _position = position; 
        Height = size;
        Width = size;
    }
    
    public Sprite(string texture, Vector2 position, int height , int width) {
        _textureName = texture;
        _texture = Utils._content.Load<Texture2D>(_textureName);
        _position = position; 
        Height = height;
        Width = width;
    }

    public Sprite()
    {
        //_position = new Vector2(Utils.screenWidth/2,Utils.screenWidth/8);
        //_texture = Utils._content.Load<Texture2D>("player");
    }

    public void SetPosition(Vector2 position)
    {
        _position = position;
    }

    public Vector2 getPosition()
    {
        return _position;
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
    
    public void DrawTrouNoir(SpriteBatch spriteBatch,float rotation, SpriteEffects effects, Color color )
    {
        spriteBatch.Draw(_texture,Rect,null,color,rotation
            ,new Vector2(170,170)
            ,effects,0 );
    }

}
