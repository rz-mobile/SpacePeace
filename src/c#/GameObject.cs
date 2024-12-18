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
    private Rectangle _hitbox => new Rectangle((int)_position.X, (int)_position.Y, Width, Height);

    public GameObject(string texture, Vector2 position, int size):base(texture,position,size)
    {
        _position = position;
    }
    
    public GameObject(string texture, Vector2 position, int size,int nbAnimation, int nbFrame ):base(texture,position,size,nbAnimation,nbFrame)
    {
        _position = position;
    }

    public GameObject(string spritesheet, Vector2 position, int height, int width) : base(spritesheet, position,
        height, width)
    {
        _position = position;
    }
    public GameObject():base()
    {
        _position = new Vector2(300,300);
        //_hitbox = new Rectangle((int)_position.X, (int)_position.Y, _sprite._size, _sprite._size);
    }

    protected Rectangle GetHitbox()
    {
        return _hitbox;
    }

    protected void SetHitbox(Rectangle hitbox)
    {
        //_hitbox = hitbox;
    }
    

    public new void Update(GameTime gameTime){
        base.Update(gameTime);
    }

    /*public void Update(GameTime gameTime, int nbAnimation, int nbFrames){
        base.Update(gameTime,nbAnimation,nbFrames);
    }*/
    public new void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
    
    /*public void Draw(SpriteBatch spriteBatch, SpriteEffects flip)
    {
        base.Draw(spriteBatch,flip);
    }*/
    
    public new void DrawTrouNoir(SpriteBatch spriteBatch,float rotation, SpriteEffects effects, Color color )
    {
        base.DrawTrouNoir(spriteBatch, rotation, SpriteEffects.None, Color.White);
    }
    
    public void setPosition(Vector2 position)
    {
        _position = position;
    }
    
    public bool checkCollision(Rectangle rect)
    {
        return Rect.Intersects(rect);
    }
    public void setOffset(Vector2 offset)
    {
        _position += offset;
    }
    
}