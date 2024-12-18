using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class EndOfLevel : GameObject
{
    private float _rotation;
    private int _size;
    public EndOfLevel() : base("BlackHole",new Vector2(0,0),100)
    {
        _rotation = 0.0f;
    }
    
    public void Update(GameTime gameTime, bool levelcomplete)
    {
        if (levelcomplete)
        {
            Width += 1;
            Height += 1;
        }
        base.Update(gameTime);
        _rotation += (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
    
    public new void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch,_rotation, SpriteEffects.None, Color.White);
    }
}