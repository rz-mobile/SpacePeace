using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class Credits
{
    private Sprite YouWin;
    Button _quitButton;
    SpriteFont _font;
    private Array f;

    //Constructeur vide
    public Credits()
    {
        _font =  Utils._content.Load<SpriteFont>("MyMenuFont");
        f = Felicitations.GetValues(typeof(Felicitations));
        YouWin = new Sprite("YouWin",new Vector2(Utils.screenWidth/2,150),50, 250);
        _quitButton = new Button("Exit_BTN",new Vector2(Utils.screenWidth/2,300),50, 150);
    }

    //méthode Draw qui prend un SpriteBatch en entrée et qui ne renvoie rien
    //Cette méthode permet d'afficher les crédits
    public void Draw(SpriteBatch spriteBatch)
    {
        YouWin.Draw(spriteBatch);
        _quitButton.Draw(spriteBatch);
        spriteBatch.DrawString(_font,f.GetValue(Utils._currentScore%4).ToString(), new Vector2(Utils.screenWidth/4,Utils.screenHeight/8), Color.White);
    }
    
    
    //Fontion Update prend un GameTime en entrée et ne renvoie rien 
    //Cette fonction permet de mettre à jour les crédits a chaque image
    public void Update(GameTime gameTime)
    {
        _quitButton.Update(gameTime);
        if (_quitButton._clicked)
        {
            Utils.Save();
            Utils._game1.Exit();
        }
    }
}