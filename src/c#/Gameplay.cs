using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Gameplay
{
    private BackGround _backGround;
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
    private Credits _credits;

    private bool _escapePressed = false;
    Level _currentLevel;
    private UI _menu;

    public Gameplay()
    {
        _menu = new UI();
        _currentLevel = new Level("../../../src/xml/Level" + (_lvId+1)+".xml",Utils._graphics.GraphicsDevice);
        Utils._currentGameplay = this;
        _backGround = new BackGround();
        _credits = new Credits();
    }

    public void Update(GameTime gameTime)
    {

        if (!Utils._gameComplete)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (!_escapePressed)
                {
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
                if (_currentLevel._complete)
                {
                    nextLevel();
                }
            }
            _menu.Update(gameTime);
        }
        else
        {
            _credits.Update(gameTime);
        }

    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _backGround.Draw(spriteBatch);
        if (!Utils._gameComplete)
        {
            _currentLevel.Draw(spriteBatch);
            _menu.Draw(spriteBatch,_currentLevel._player);
        }
        else
        {
            _credits.Draw(spriteBatch);
        }
    }

    public void nextLevel()
    {
        _lvId = (_lvId + 1);
        if (_lvId <= Utils.LEVEL_NUMBER-1)
        {
            _currentLevel = new Level("../../../src/xml/Level" + (_lvId+1)+".xml",Utils._graphics.GraphicsDevice);
        }
        else
        {
            Utils._gameComplete = true;
        }
        
    }

    public void RestartLevel()
    {
        _currentLevel = new Level("../../../src/xml/Level" + (_lvId+1)+".xml",Utils._graphics.GraphicsDevice);
    }
}