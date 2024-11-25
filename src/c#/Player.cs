using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Player : GameObject
{
    Vector2 speed = new Vector2(0, 0);

    public Player(Texture2D texture, Hitbox hitbox) : base(texture, hitbox)
    {
        
    }
    public void Initialize(){}
    
    public new void Update(GameTime gameTime)
    {
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            speed.X = 10;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            speed.X = -10;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            speed.Y = 10;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            speed.Y = -10;
        }
        position = new Vector2(position.X + speed.X, position.Y + speed.Y);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
}