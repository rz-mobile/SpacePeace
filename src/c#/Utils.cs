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
    public static Game1 _currentGame;
    public static bool _paused;
    public const int LEVEL_NUMBER = 3;

    public static int _score = 0;
    //public static Dictionary<string,Texture2D> _textures;
    public static bool _isPlaying;
    public static bool _leftMousePressed;

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

    public static int addScore(int score)
    {
        _score += score;
        return score;
    }
}