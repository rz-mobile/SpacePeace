using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class EndOfLevel : GameObject
{
    private int _drotation;
    private float _rotation;
    public EndOfLevel() : base("BlackHole",new Vector2(100,300),100)
    {
        _rotation = 0.0f;
        _drotation = 0;
    }
    
    public void UpdateTrouNoir(GameTime gameTime, bool levelcomplete)
    {
        if (levelcomplete)
        {
            Width += 1;
            Height += 1;
        }
        
        Update(gameTime);
        _drotation += gameTime.ElapsedGameTime.Milliseconds;
        _rotation = MathHelper.ToRadians(_drotation);
        if (_drotation >= 360000000)
        {
            _drotation = 0;
        }
        
    }
    
    public void DrawTrouNoir(SpriteBatch spriteBatch)
    {
        base.DrawTrouNoir(spriteBatch,_rotation, SpriteEffects.None, Color.White);
    }
}