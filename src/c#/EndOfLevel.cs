using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class EndOfLevel : GameObject
{
    
    private int _drotation; // rotation en degré
    private float _rotation; // rotation en radian
    
    //Constructeur Vide
    public EndOfLevel() : base("BlackHole",new Vector2(100,300),100)
    {
        _rotation = 0.0f;
        _drotation = 0;
    }
    
    //Prend un GameTime et un booleen et ne renvoi rien, actualise l'objet
    public void Update(GameTime gameTime, bool levelcomplete)
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
    
    //Prends un SpriteBatch et ne renvoie rien, affiche l'objet
    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch,_rotation, SpriteEffects.None, Color.White);
    }
}