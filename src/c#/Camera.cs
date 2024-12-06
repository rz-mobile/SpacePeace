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
    
    public void setPosition(Vector2 position)
    {
        _position = position;
    }
    public Vector2 moveCamera(Vector2 speed)
    {
        Vector2 position = _position;
        
        _position = new Vector2(_position.X + speed.X,_position.Y);
        
        
        return -(_position - position);
    }
    
}