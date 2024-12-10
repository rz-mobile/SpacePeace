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

    public void Update(GameTime gameTime,bool paused)
    {
        if (paused)
        {
            if (_quitButton.Clicked())
            {
                Utils._isPlaying = false;
            }

            if (_resumeButton.Clicked())
            {
                Utils._paused = !Utils._paused;
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch,bool paused,Player p)
    {
        string output = "Health : " + p._ptVie;
        
        spriteBatch.DrawString(_font, output, _fontPos, Color.White);
        if (paused)
        {
            _quitButton.Draw(spriteBatch);
            _resumeButton.Draw(spriteBatch);
        }
    }
}