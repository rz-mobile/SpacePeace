using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Sprite {
    private Texture2D _texture;
    protected static Vector2 _position;
    private int _size = 100;
    private static readonly int _sizeMin = 10;
    private static readonly int _sizeMax = 5000;
    private Color _color = Color.White;
    public Texture2D _Texture { get => _texture; init => _texture = value; }
    public int _Size { get => _size;
        set
        {
            if (value >= _sizeMin && value <= _sizeMax)
            {
                _size = value;
            }else if (value < _sizeMin)
            {
                _size = _sizeMin;
            }
            else
            {
                _size = _sizeMax;
            }
        }
    }
    public Rectangle _Rect { get => new Rectangle((int) _position.X, (int) _position.Y, _size, _size); }

    public Sprite(Texture2D texture, Vector2 position, int size) {
        _Texture = texture;
        _position = position; 
        _Size = size;
    }

    public void setPosition(Vector2 position)
    {
        _position = position;
    }
    
    public void Update(GameTime gameTime) {
        
        if (Keyboard.GetState().IsKeyDown(Keys.Up)) {/*...*/ }
        // ...
    }
    
    public void Draw(SpriteBatch spriteBatch) {
        var origin = new Vector2(_texture.Width / 2f, _texture.Height / 2f);
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
        var origin = new Vector2(_texture.Width / 2f, _texture.Height / 2f);
        spriteBatch.Draw(   _texture, // Texture2D,
            _Rect, // Rectangle destinationRectangle,
            src, // Nullable<Rectangle> sourceRectangle,
            _color, //  Color,
            0.0f, //  float rotation,
            origin,  // Vector2 origin,
            SpriteEffects.None, // SpriteEffects effects,
            0f ); // float layerDepth
    }

}
