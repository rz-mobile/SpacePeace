using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Button
{
    Sprite _sprite;
    private bool alreadyCLicked = false;
    public bool _clicked { get; private set; } = false;

    //Constructeur
    
    public Button(string texture, Vector2 position, int size)
    {
        _sprite = new Sprite(texture, position, size);
    }
    
    public Button(string texture, Vector2 position, int height, int width)
    {
        _sprite = new Sprite(texture, position, height, width);
    }

    //méthode Draw qui prend un SpriteBatch en entrée et qui renvoi rien
    //Cette méthode permet de dessiner les Boutons
    public void Draw(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch);
    }

    //Fontion Update prend un GameTime en entrée et renvoi rien 
    //Cette fonction permet de m'être à jour les boutons.
    public void Update(GameTime gameTime)
    {
        if (Mouse.GetState().LeftButton == ButtonState.Pressed)
        {
            if (!alreadyCLicked)
            {
                alreadyCLicked = true;
                _clicked = _sprite.Rect.Contains(Mouse.GetState().Position);
            }
        }
        else
        {
            alreadyCLicked = false;
            _clicked = false;
        }
    }
}