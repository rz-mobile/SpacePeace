using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Button
{
    Sprite _sprite;
    private bool alreadyCLicked = false;
    public bool _clicked { get; private set; } = false;

    //Constructeur prenant une chaine de caracteres, une Vector2 et un entier
    public Button(string texture, Vector2 position, int size)
    {
        _sprite = new Sprite(texture, position, size);
    }
    //Constructeur prenant une chaine de caracteres, une Vector2 et 2 entiers
    public Button(string texture, Vector2 position, int height, int width)
    {
        _sprite = new Sprite(texture, position, height, width);
    }

    //méthode Draw qui prends un SpriteBatch en entrée et qui ne renvoie rien
    //Cette méthode permet de dessiner le Bouton
    public void Draw(SpriteBatch spriteBatch)
    {
        _sprite.Draw(spriteBatch);
    }

    //Fontion Update prend un GameTime en entrée et ne renvoie rien 
    //Cette fonction permet de m'être à jour les boutons a chaque image
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