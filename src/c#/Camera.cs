using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Camera
{
    public Vector2 _position;
    
    //Constructeur
    public Camera(Vector2 position)
    {
        _position = position;
    }
    
    //méthode setPosition qui prend un Vector2 en entrée et qui renvoi rien
    //Cette méthode permet d'avoir un setteur de Position
    public void setPosition(Vector2 position)
    {
        _position = position;
    }
    
    //Méthode moveCamera qui prend un Vector2 en entrée et qui renvoi un Vector2
    //Cette méthode permet de faire bouger la Caméra
    public Vector2 moveCamera(Vector2 speed)
    {
        Vector2 position = _position;
        
        _position = new Vector2(_position.X + speed.X,_position.Y);
        
        
        return -(_position - position);
    }
    
}