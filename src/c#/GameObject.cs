using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SpacePeace;
[XmlInclude(typeof(Player))]
[XmlRoot("GameObject", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/gameObjects")]
[Serializable]
public abstract class GameObject : AnimatedSprite
{
    private Rectangle _hitbox => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

    public GameObject(string texture, Vector2 position, int size):base(texture,position,size)
    {
        Position = position;
    }

    public GameObject(string texture, Vector2 position, int size,int nbAnimation, int nbFrame ):base(texture,position,size,nbAnimation,nbFrame)
    {
        Position = position;
    }
    public GameObject():base()
    {
        Position = new Vector2(300,300);
        //_hitbox = new Rectangle((int)Position.X, (int)Position.Y, _sprite._size, _sprite._size);
    }

    protected Rectangle GetHitbox()
    {
        return _hitbox;
    }

    protected void SetHitbox(Rectangle hitbox)
    {
        //_hitbox = hitbox;
    }
    

    public void Update(GameTime gameTime){
        base.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
    
    public bool checkCollision(Rectangle rect)
    {
        return Rect.Intersects(rect);
    }
    public void setOffset(Vector2 offset)
    {
        Position = Position + offset;
    }
    
}