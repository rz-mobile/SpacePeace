using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

[Serializable]
[XmlRoot("Enemy", Namespace ="http://www.univ-grenoble-alpes.fr/Enemy" )]

public class Enemy : GameObject
{
    private Vector2 speed;
    private float gravity;
    private int ptVie;


    public Enemy(Texture2D texture, Vector2 position, int size) : base(texture, position, size)
    {
        speed = new Vector2(0.0f, 0.0f);
        gravity = 0.1f;
        ptVie = 1;
        
    }
    public void Initilize(){}

    public new void Update(GameTime gameTime)
    {
        speed.X = -0.1f;

        //speed = new Vector2(0.1f, speed.Y+gravity);
        // mettre les conditions de mort
        _position = new Vector2(_position.X + speed.X, _position.Y + speed.Y);

    }
    
    /**
    public void draw(SpriteBatch spriteBatch)
    {
        
    }
    **/





    [XmlAttribute("Pv")] public Int _Pv { init; get; }
    [XmlAttribute("Id")] public Int _Id { init; get; }
    [XmlAttribute("Degats")] public Int _Degats { init; get; }
    
    public class Int
    {
        [XmlAttribute("id")] public int _id { init; get; }
    }
    
    
}