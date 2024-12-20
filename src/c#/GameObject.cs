using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SpacePeace;

public abstract class GameObject : AnimatedSprite
{

    //Constructeur qui prends une chaine de caracteres un Vector2 et un entier
    public GameObject(string texture, Vector2 position, int size):base(texture,position,size)
    {
        _position = position;
    }
    //Constructeur qui prends une chaine de caracteres un Vector2 et 3 entiers
    public GameObject(string texture, Vector2 position, int size,int nbAnimation, int nbFrame ):base(texture,position,size,nbAnimation,nbFrame)
    {
        _position = position;
    }
    //Constructeur qui prends une chaine de caracteres un Vector2 et 2 entiers
    public GameObject(string spritesheet, Vector2 position, int height, int width) : base(spritesheet, position,
        height, width)
    {
        _position = position;
    }
    //Constructeur vide
    public GameObject():base(){}
    
    
    //Fontion Update prend un GameTime en entrée et ne renvoie rien.
    //Cette fonction permet de mettre à jour les GameObjects.
    public new void Update(GameTime gameTime){
        base.Update(gameTime);
    }
    
    //méthode Draw qui prend un SpriteBatch en entrée et qui ne renvoie rien.
    //Cette méthode permet de dessiner les GameObject.
    public new void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
    
    
    //méthode Draw qui prend un SpriteBatch,un float ,un SpriteEffect et un Color en entrée et qui ne renvoie rien.
    //Cette méthode permet de dessiner les GameObject.
    public new void Draw(SpriteBatch spriteBatch,float rotation, SpriteEffects effects, Color color )
    {
        base.Draw(spriteBatch, rotation, SpriteEffects.None, Color.White);
    }
    
    //Fontion setPosition prend un Vector2 en entrée et ne renvoie rien 
    //Cette fonction permet d'affecter la position
    public void setPosition(Vector2 position)
    {
        _position = position;
    }
    
    //Fontion checkCollision prend un Rectangle en entrée et renvoie un booléen 
    //Cette fonction permet si il y a une collision.
    public bool checkCollision(Rectangle rect)
    {
        return Rect.Intersects(rect);
    }

    //Fontion SetOffset prend un rectangle en entrée et ne renvoie rien 
    //Cette fonction permet d'affecter le decalage de la camera
    public void setOffset(Vector2 offset)
    {
        _position += offset;
    }
    
}