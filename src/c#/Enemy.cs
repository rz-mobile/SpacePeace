using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

[Serializable]
[XmlRoot("Enemy", Namespace ="http://www.univ-grenoble-alpes.fr/Enemy" )]

public class Enemy : GameObject
{
    private Vector2 _speed;
    private float _gravity;
    private int _ptVie;
    private bool _surSol = false;
    public bool _dead = false;
    public Rectangle _topHitbox{get => new Rectangle((int)_position.X-(_size/2)+6, (int)_position.Y-(_size/2), _size-12, 4);}
    [XmlAttribute("degats")] public int _degats { init; get; }

    public Enemy(string texture, Vector2 position, int size,int degats) : base(texture, position, size)
    {
        _degats = degats;
        _speed = new Vector2(0.0f, 0.0f);
        _gravity = 0.1f;
        _ptVie = 1;
        
    }

    public void spawn(Vector2 position)
    {
        _dead = false;
        _position = position;
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
        _speed = new Vector2(_speed.X, _speed.Y+_gravity);
        _speed.X = -0.5f;
        
        _position = new Vector2(_position.X + _speed.X, _position.Y + _speed.Y);

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        rect.SetData(new Color[] { Color.White });
        spriteBatch.Draw(rect,_topHitbox, Color.Yellow);
    }
    






    
    
    
}