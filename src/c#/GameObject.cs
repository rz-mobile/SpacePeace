using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SpacePeace;
[XmlInclude(typeof(Player))]
[XmlRoot("GameObject", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/gameObjects")]
[Serializable]
public abstract class GameObject : Sprite
{
    private Rectangle _hitbox => new Rectangle((int)_position.X, (int)_position.Y, _width, _height);

    public GameObject(string texture, Vector2 position, int size):base(texture,position,size)
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
    

    public void Update(GameTime gameTime){
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
    
    public bool checkCollision(Rectangle rect)
    {
        return _rect.Intersects(rect);
    }
    public void setOffset(Vector2 offset)
    {
        _position = _position + offset;
    }
    
}