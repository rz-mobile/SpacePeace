using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class UI
{
    SpriteFont font;
    private Vector2 fontPos;
    Button quitButton;
    Button resumeButton;

    public UI()
    {
        font = Utils._content.Load<SpriteFont>("MyMenuFont");
        quitButton = new Button("ship1",new Vector2(200,200),200);
        resumeButton = new Button("ship2",new Vector2(600,200),200);
    }

    public void Update(GameTime gameTime)
    {
        if (quitButton.Clicked())
        {
            Utils._currentGame.Exit();
            //Console.WriteLine("Quit");
        }

        if (resumeButton.Clicked())
        {
            Utils.paused = !Utils.paused;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        string output = "Paused";
        //Vector2 FontOrigin = font.MeasureString(output) / 2;
        
        spriteBatch.DrawString(font, output, fontPos, Color.White);
        quitButton.Draw(spriteBatch);
        resumeButton.Draw(spriteBatch);
    }
}