using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class Credits
{
    private Sprite YouWin;
    Button _quitButton;

    public Credits()
    {
        YouWin = new Sprite("YouWin",new Vector2(Utils.screenWidth/2,150),50, 250);
        _quitButton = new Button("Exit_BTN",new Vector2(Utils.screenWidth/2,300),50, 150);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        YouWin.Draw(spriteBatch);
        _quitButton.Draw(spriteBatch);
    }

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