using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

[Serializable]
[XmlRoot("Enemy", Namespace ="http://www.univ-grenoble-alpes.fr/Enemy" )]

public class Enemy : GameObject
{
    private Vector2 _speed;
    private float _gravity;
    private int _ptVie;


    public Enemy(string texture, Vector2 position, int size) : base(texture, position, size)
    {
        _speed = new Vector2(0.0f, 0.0f);
        _gravity = 0.1f;
        _ptVie = 1;
        
    }
    public void Initilize(){}

    public new void Update(GameTime gameTime)
    {
        _speed.X = -0.1f;
        
        _position = new Vector2(_position.X + _speed.X, _position.Y + _speed.Y);

    }
    





    [XmlAttribute("Pv")] public Int _Pv { init; get; }
    [XmlAttribute("Id")] public Int _Id { init; get; }
    [XmlAttribute("Degats")] public Int _Degats { init; get; }
    
    public class Int
    {
        [XmlAttribute("id")] public int _id { init; get; }
    }
    
    
}