using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Gameplay
{
    private bool paused
    {
        get
        {
            return Utils.paused;
        } set
        {
            Utils.paused = value;
        }
    }

    private bool escapePressed = false;
    level currentLevel;
    private UI menu;

    public Gameplay()
    {
        menu = new UI();
        currentLevel = new level("../../../src/xml/Level1.xml",Utils._graphics.GraphicsDevice);
    }

    public void Update(GameTime gameTime)
    {
        /*if (Keyboard.GetState().IsKeyDown(Keys.Add))
        {
            currentLevel = new level("../../../src/xml/map.xml",Utils._graphics.GraphicsDevice);
        }*/
        
        
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            if (!escapePressed)
            {
                currentLevel = new level("../../../src/xml/map.xml",Utils._graphics.GraphicsDevice);
                paused = !paused;
            }
            escapePressed = true;
        }
        else
        {
            escapePressed = false;
        }
            
        if (!paused)
        {
            currentLevel.Update(gameTime);
        }
        else
        {
            menu.Update(gameTime);
        }
        //Console.WriteLine(Mouse.GetState().X + " " + Mouse.GetState().Y);
    }

    public void Draw(SpriteBatch spriteBatch)
    {

        currentLevel.Draw(spriteBatch);
        if (paused)
        {
            menu.Draw(spriteBatch);
        }
    }
}