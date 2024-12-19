using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

[Serializable]
[XmlRoot("Enemy", Namespace ="http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/gameObjects" )]

public class Enemy : GameObject
{
    private Vector2 _move;
    private float _gravity;
    private bool _surSol = false;
    public bool _dead = false;
    public Rectangle _topHitbox{get => new Rectangle((int)_position.X-(Width/2)+6, (int)_position.Y-(Height/2), Width-12, 4);}
    public Rectangle _leftHitbox{get => new Rectangle((int)_position.X - (Width/2), (int)_position.Y-(Height/2)+3, 4, Height-6);}

    [XmlElement("degats")] public int _degats { init; get; }
    [XmlElement("Pv")] public int _ptVie;
    [XmlElement("speed")]public float _speed;
    
    public Enemy(string texture, Vector2 position, int size,int degats) : base(texture, position, size, 0, 2)
    {
        _degats = degats;
        _move = new Vector2(0.0f, 0.0f);
        _gravity = 0.5f;
        _ptVie = 1;
        
    }

    public Enemy()
    {
        _texture = Utils._content.Load<Texture2D>("player");
        _position = new Vector2(0.0f, 0.0f);
        Height = 60;
        Width = 60;
        _move = new Vector2(0.0f, 0.0f);
        _gravity = 0.1f;
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
        _move = new Vector2(_move.X,  - _gravity);
    }

    
    public void setGravity(float gravity)
    {
        _gravity = gravity;
    }

    public bool checkTopCollision(Rectangle rect)
    {
        return _topHitbox.Intersects(rect);
    }

    public bool checkleftCollision(Rectangle rect)
    {
        return _leftHitbox.Intersects(rect);
    }
    public void Initilize(){}

    public new void Update(GameTime gameTime)
    {
        base.Update(gameTime, 0,2 );
        _move = new Vector2(_move.X, _move.Y+_gravity);
        _move.X = -_speed;
        
        _position = new Vector2(_position.X + _move.X, _position.Y + _move.Y);

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch, SpriteEffects.FlipHorizontally, Color.Red);
        Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        rect.SetData(new Color[] { Color.White });
    }
}