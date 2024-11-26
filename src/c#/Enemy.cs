using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

[Serializable]
[XmlRoot("Enemy", Namespace ="http://www.univ-grenoble-alpes.fr/Enemy" )]

public class Enemy : GameObject
{
    Vector2 speed = new Vector2(0.0f, 0.0f);
    Vector2 position = _position ;
    private float gravity;
    private bool isJumping;
    protected double ptVie;


    public Enemy(Texture2D texture, Vector2 position, int size) : base(texture, position, size)
    {
        
    }
    public void setGravity(float gravity)
    {
        this.gravity = gravity;
    }

    public void Initilize()
    {
        setGravity(1.0f);
        ptVie = 1;
    }

    public new void Update(GameTime gameTime)
    {
        position = new Vector2(position.X+speed.X, position.Y + speed.Y);
        speed = new Vector2(5.0f, 0.0f);
        
        // mettre les conditions de mort
        
    }

    protected override void Draw(SpriteBatch spriteBatch)
    {
        throw new NotImplementedException();
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