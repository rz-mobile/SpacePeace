using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SpacePeace;

public abstract class GameObject : AnimatedSprite
{
    private Rectangle _hitbox => new Rectangle((int)_position.X, (int)_position.Y, Width, Height);

    //Constructeur
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
        //_hitbox = new Rectangle((int)_position.X, (int)_position.Y, _sprite._size, _sprite._size);
    }

    //Fontion GetHitbox prend rien en entrée et renvoie un rectangle. 
    //Cette fonction permet d'avoir un getteur de la Hitbox.
    protected Rectangle GetHitbox()
    {
        return _hitbox;
    }

    //Fontion SetHitbox prend un rectangle en entrée et renvoie rien 
    //Cette fonction permet d'avoir un setteur de la Hitbox.
    protected void SetHitbox(Rectangle hitbox)
    {
        //_hitbox = hitbox;
    }
    
    //Fontion Update prend un GameTime en entrée et renvoi rien.
    //Cette fonction permet de m'être à jour les GameObjects.
    public new void Update(GameTime gameTime){
        base.Update(gameTime);
    }

    /*public void Update(GameTime gameTime, int nbAnimation, int nbFrames){
        base.Update(gameTime,nbAnimation,nbFrames);
    }*/
    
    //méthode Draw qui prend un SpriteBatch en entrée et qui renvoi rien.
    //Cette méthode permet de dessiner les GameObject.
    public new void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
    
    /*public void Draw(SpriteBatch spriteBatch, SpriteEffects flip)
    {
        base.Draw(spriteBatch,flip);
    }*/
    
    //méthode DrawTrouNoir qui prend un SpriteBatch en entrée et qui renvoi rien.
    //Cette méthode permet de dessiner les TrouNoirs.
    public new void DrawTrouNoir(SpriteBatch spriteBatch,float rotation, SpriteEffects effects, Color color )
    {
        base.DrawTrouNoir(spriteBatch, rotation, SpriteEffects.None, Color.White);
    }
    
    //Fontion setPosition prend un Vector2 en entrée et renvoi rien 
    //Cette fonction permet d'avoir un setteur de la position.
    public void setPosition(Vector2 position)
    {
        _position = position;
    }
    
    //Fontion checkCollision prend un Rectangle en entrée et renvoi un booléen 
    //Cette fonction permet si il y a une colision.
    public bool checkCollision(Rectangle rect)
    {
        return Rect.Intersects(rect);
    }

    //Fontion SetOffset prend un rectangle en entrée et renvoi rien 
    //Cette fonction permet d'avoir un setteur de offset.
    public void setOffset(Vector2 offset)
    {
        _position += offset;
    }
    
}