using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Gameplay
{
    private int _lvId = 0;
    private bool _paused
    {
        get
        {
            return Utils._paused;
        } set
        {
            Utils._paused = value;
        }
    }

    private bool _escapePressed = false;
    Level _currentLevel;
    private UI _menu;

    public Gameplay()
    {
        _menu = new UI();
        _currentLevel = new Level("../../../src/xml/Level" + (_lvId+1)+".xml",Utils._graphics.GraphicsDevice);
    }

    public void Update(GameTime gameTime)
    {
        
        
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            if (!_escapePressed)
            {
                _lvId = (_lvId + 1) % Utils.LEVEL_NUMBER;
                _currentLevel = new Level("../../../src/xml/Level" + (_lvId+1)+".xml",Utils._graphics.GraphicsDevice);
                _paused = !_paused;
            }
            _escapePressed = true;
        }
        else
        {
            _escapePressed = false;
        }
            
        if (!_paused)
        {
            _currentLevel.Update(gameTime);
        }
        else
        {
            _menu.Update(gameTime);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {

        _currentLevel.Draw(spriteBatch);
        if (_paused)
        {
            _menu.Draw(spriteBatch);
        }
    }
}