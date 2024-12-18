using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SpacePeace;

public class Shoot : GameObject
{
    private Vector2 speed;
    public Shoot(String texture, Vector2 position, int size): base(texture, position, size)
    {
        speed = new Vector2(10, 0);
    }

    public new void Update(GameTime gameTime)
    {
        _position = new Vector2(_position.X + 10, _position.Y);
        
    }

}