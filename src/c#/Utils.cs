using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public static class Utils
{
    public static ContentManager _content;
    public static GraphicsDeviceManager _graphics;
    //public static Game1 _currentGame;
    public static Gameplay _currentGameplay;
    public static bool _paused;
    public const int LEVEL_NUMBER = 1;
    public static bool _isPlaying;
    public static bool _gameOver = false;
    public static bool _gameComplete = false;

    public static int screenWidth
    {
        get
        {
            return _graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.Viewport.Width;
        }
    }
    
    
    public static int screenHeight
    {
        get
        {
            return _graphics.PreferredBackBufferHeight = _graphics.GraphicsDevice.Viewport.Height;
        }
    }

    public static void RestartLevel()
    {
        _currentGameplay.RestartLevel();
    }

}