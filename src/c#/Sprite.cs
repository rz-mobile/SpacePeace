using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Sprite {
    private Texture2D _texture;
    public Vector2 _position { get;protected set; }
    private int _size = 100;
    private static readonly int _sizeMin = 10;
    private static readonly int _sizeMax = 5000;
    private Color _color = Color.White;
    public Texture2D _Texture { get => _texture; init => _texture = value; }

    
    public Rectangle _Rect { get => new Rectangle((int) _position.X - _size/2, (int) _position.Y - _size/2, _size, _size); }

    public Sprite(String texture, Vector2 position, int size) {
        //_Texture = texture;
        _Texture = Utils._content.Load<Texture2D>(texture);
        _position = position; 
        _size = size;
    }

    public void setPosition(Vector2 position)
    {
        _position = position;
    }
    
    public void Update(GameTime gameTime) {
        
        if (Keyboard.GetState().IsKeyDown(Keys.Up)) {/*...*/ }
        // ...
    }
    
    /*public void Draw(SpriteBatch spriteBatch) {
        Console.WriteLine(_position);
        var origin = new Vector2(_Rect.Width / 2f,_Rect.Height / 2f);
        spriteBatch.Draw(   _texture, // Texture2D,
            _Rect, // Rectangle destinationRectangle,
            null, // Nullable<Rectangle> sourceRectangle,
            _color, //  Color,
            0.0f, //  float rotation,
            origin,  // Vector2 origin,
            SpriteEffects.None, // SpriteEffects effects,
            0f ); // float layerDepth
    }

    public void Draw(SpriteBatch spriteBatch, Rectangle src)
    {
        var origin = new Vector2(_Rect.Width / 2f, _Rect.Height / 2f);
        spriteBatch.Draw(   _texture, // Texture2D,
            _Rect, // Rectangle destinationRectangle,
            src, // Nullable<Rectangle> sourceRectangle,
            _color, //  Color,
            0.0f, //  float rotation,
            origin,  // Vector2 origin,
            SpriteEffects.None, // SpriteEffects effects,
            0f ); // float layerDepth
    }*/
    public void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw(   _texture, // Texture2D,
            _Rect, // Rectangle destinationRectangle,
            null, // Nullable<Rectangle> sourceRectangle,
            _color); // float layerDepth
    }

    public void Draw(SpriteBatch spriteBatch, Rectangle src)
    {
        spriteBatch.Draw(   _texture, // Texture2D,
            _Rect, // Rectangle destinationRectangle,
            src, // Nullable<Rectangle> sourceRectangle,
            _color ); // float layerDepth
    }

}
