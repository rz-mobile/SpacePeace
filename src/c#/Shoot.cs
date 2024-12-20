using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpacePeace;

public class Shoot : GameObject
{
    private Vector2 speed;
    public const int _degats = 1;
    public bool Detruit = false;
    
    public Rectangle _bottomHitbox {get => new Rectangle((int)_position.X-(Width/2)+6, (int)_position.Y+(Height/2), Width-12, 4);}
    public Rectangle _rightHitbox{get => new Rectangle((int)_position.X+(Width/2), (int)_position.Y-(Height/2)+3, 4, Height-6);}
    public Rectangle _leftHitbox{get => new Rectangle((int)_position.X - (Width/2), (int)_position.Y-(Height/2)+3, 4, Height-6);}
    public Rectangle _topHitbox{get => new Rectangle((int)_position.X-(Width/2)+6, (int)_position.Y-(Height/2), Width-12, 4);}

    public Shoot(String texture, Vector2 position, int size): base(texture, position, size)
    {
        speed = new Vector2(10, 0);
    }

    public Shoot()
    {
        _position = Utils._player._position;
        speed = new Vector2(10, 0);
        _texture = Utils._content.Load<Texture2D>("Missile");
        Height = 30;
        Width = 30;
    }

    public new void Update(GameTime gameTime)
    {
        _position = new Vector2(_position.X + 10, _position.Y);
        
    }
    //ne prends rien et ne retourne rien, affecte Detruit a vrai
    public void touche()
    {
        Detruit = true;
        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        rect.SetData(new Color[] { Color.White });
       
    }
}