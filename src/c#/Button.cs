using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Button
{
    Sprite _sprite;
    private bool alreadyCLicked = false;
    public bool _clicked { get; private set; } = false;

    public Button(string texture, Vector2 position, int size)
    {
        _sprite = new Sprite(texture, position, size);
    }
    
    public Button(string texture, Vector2 position, int height, int width)
    {
        _sprite = new Sprite(texture, position, height, width);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch);
    }

    public void Update(GameTime gameTime)
    {
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            if (!alreadyCLicked)
            {
                alreadyCLicked = true;
                _clicked = _sprite.Rect.Contains(Mouse.GetState().Position);
            }
        }
        else
        {
            alreadyCLicked = false;
            _clicked = false;
        }
    }

    /*public bool Clicked()
    {
        if (!alreadyCLicked)
        {
            alreadyCLicked = true;
            return _sprite.Rect.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed;
        }
        else
        {
            return false;
        }
        
    }*/
}