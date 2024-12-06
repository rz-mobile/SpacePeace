using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Button
{
    Sprite _sprite;

    public Button(string texture, Vector2 position, int size)
    {
        _sprite = new Sprite(texture, position, size);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch);
    }

    public bool Clicked()
    {
        return _sprite._Rect.Contains(Mouse.GetState().Position) && Mouse.GetState().LeftButton == ButtonState.Pressed;
    }
}