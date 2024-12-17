using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

[Serializable]
[XmlRoot("Enemy", Namespace ="http://www.univ-grenoble-alpes.fr/Enemy" )]

public class Enemy : GameObject
{
    private int[] tabFrame = {2,14,9,7};
    private Vector2 _speed;
    private float _gravity;
    private bool _surSol = false;
    public bool _dead = false;
    public Rectangle _topHitbox{get => new Rectangle((int)Position.X-(Width/2)+6, (int)Position.Y-(Height/2), Width-12, 4);}
    [XmlAttribute("degats")] public int _degats { init; get; }
    [XmlAttribute("Pv")] public int _ptVie;
    
    public Enemy(string texture, Vector2 position, int size,int degats) : base(texture, position, size, 0, 2)
    {
        _degats = degats;
        _speed = new Vector2(0.0f, 0.0f);
        _gravity = 0.1f;
        _ptVie = 1;
        
    }

    public Enemy() : base()
    {
        _speed = new Vector2(0.0f, 0.0f);
        _gravity = 0.1f;
    }
    
    
    public void spawn(Vector2 position)
    {
        _dead = false;
        Position = position;
    }

    public void die()
    {
        _dead = true;
    }
    public void groundReaction()
    {
        //_surSol = true;
        _speed = new Vector2(_speed.X,  - _gravity);
    }


    /*public void setOffset(Vector2 offset)
    {
        _position = _position + offset;
    }*/
    public void setGravity(float gravity)
    {
        _gravity = gravity;
    }

    public bool checkTopCollision(Rectangle rect)
    {
        return _topHitbox.Intersects(rect);
    }
    public void Initilize(){}

    public new void Update(GameTime gameTime)
    {
        base.Update(gameTime, 0,2 );
            _speed = new Vector2(_speed.X, _speed.Y+_gravity);
        _speed.X = -0.1f;
        
        Position = new Vector2(Position.X + _speed.X, Position.Y + _speed.Y);

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch, SpriteEffects.FlipHorizontally);
        /*Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        rect.SetData(new Color[] { Color.White });
        spriteBatch.Draw(rect,_topHitbox, Color.Yellow);*/
    }
    






    
    
    
}