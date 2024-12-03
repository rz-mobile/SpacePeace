using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Camera
{
    public Vector2 _position;

    public Camera(Vector2 position)
    {
        _position = position;
    }
    
    /*public void Follow(Rectangle target, Vector2 screenSize)
    {
        position = new Vector2(
            -target.X + (screenSize.X / 2 - target.Width / 2),
            -target.Y + (screenSize.Y / 2 - target.Height / 2));
    }*/
    public void setPosition(Vector2 position)
    {
        _position = position;
    }
    public Vector2 moveCamera(Vector2 speed)
    {
        Vector2 position = _position;
        
        //_position = newPosition;
        _position = new Vector2(_position.X + speed.X,_position.Y);
        
        
        return -(_position - position);
    }
    
}