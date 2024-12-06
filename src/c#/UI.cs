using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class UI
{
    SpriteFont _font;
    private Vector2 _fontPos;
    Button _quitButton;
    Button _resumeButton;

    public UI()
    {
        _font = Utils._content.Load<SpriteFont>("MyMenuFont");
        _quitButton = new Button("ship1",new Vector2(200,200),200);
        _resumeButton = new Button("ship2",new Vector2(600,200),200);
    }

    public void Update(GameTime gameTime)
    {
        if (_quitButton.Clicked())
        {
            Utils._currentGame.Exit();
        }

        if (_resumeButton.Clicked())
        {
            Utils._paused = !Utils._paused;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        string output = "Paused";
        
        spriteBatch.DrawString(_font, output, _fontPos, Color.White);
        _quitButton.Draw(spriteBatch);
        _resumeButton.Draw(spriteBatch);
    }
}