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
    
    //Constructeur prenant une chaine da caracteres,un Vector1 et 2 entiers
    public Enemy(string texture, Vector2 position, int size,int degats) : base(texture, position, size, 0, 2)
    {
        _degats = degats;
        _move = new Vector2(0.0f, 0.0f);
        _gravity = 0.5f;
        _ptVie = 1;
        
    }
    //Constructeur vide
    public Enemy()
    {
        _texture = Utils._content.Load<Texture2D>("player");
        _position = new Vector2(0.0f, 0.0f);
        Height = 60;
        Width = 60;
        _move = new Vector2(0.0f, 0.0f);
        _gravity = 0.1f;
    }
    
    //Fontion spawn prend un Vector2 en entrée et ne renvoie rien 
    //Cette fonction permet de retenir sa position et qu'il n'est pas mort.
    public void spawn(Vector2 position)
    {
        _dead = false;
        _position = position;
    }

    //Fontion die qui ne prend rien en entrée et renvoie rien 
    //Cette fonction permet de m'être l'attribut _dead à vrai.
    public void die()
    {
        _dead = true;
    }
    
    //Fontion Update prend rien en entrée et ne renvoie rien 
    //Cette fonction applique la reaction du sol a l'ennemi
    public void groundReaction()
    {
        _move = new Vector2(_move.X,  - _gravity);
    }

    //Fontion setGravity prend un float en entrée et ne renvoie rien 
    //Cette fonction affecte une valeur à _gravity
    public void setGravity(float gravity)
    {
        _gravity = gravity;
    }

    //Fontion checkTopCollision prend un Rectangle en entrée et renvoie un booléen 
    //Cette fonction permet si il y a une colision sur le dessus.
    public bool checkTopCollision(Rectangle rect)
    {
        return _topHitbox.Intersects(rect);
    }

    //Fontion checkleftCollision prend un Rectangle en entrée et renvoie un booléen 
    //Cette fonction permet si il y a une colision à gauche.
    public bool checkleftCollision(Rectangle rect)
    {
        return _leftHitbox.Intersects(rect);
    }

    
    //Fontion Update prend un GameTime en entrée et ne renvoi rien.
    //Cette fonction permet de mettre à jour les Ennemis.
    public new void Update(GameTime gameTime)
    {
        base.Update(gameTime, 0,2 );
        _move = new Vector2(_move.X, _move.Y+_gravity);
        _move.X = -_speed;
        
        _position = new Vector2(_position.X + _move.X, _position.Y + _move.Y);

    }

    //méthode Draw qui prend un SpriteBatch en entrée et qui ne renvoie rien.
    //Cette méthode permet d'afficher les Ennemis.
    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch, SpriteEffects.FlipHorizontally, Color.Red);
        Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        rect.SetData(new Color[] { Color.White });
    }
}