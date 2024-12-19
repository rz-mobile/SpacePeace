using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public static class Utils
{
    public static ContentManager _content;
    public static GraphicsDeviceManager _graphics;
    public static Gameplay _currentGameplay;
    public static bool _paused;
    public static readonly int LEVEL_NUMBER = 1;
    public static bool _isPlaying;
    public static bool _gameOver = false;
    public static bool _gameComplete = false;
    public static int _currentLevelId;
    public static string _currentPlayer = String.Empty;
    public static int _currentScore;
    public static XmlManager<Saves> saveManager;
    public static Saves _saves;
    public static Game1 _game1;
    

    public static int screenWidth
    {
        get
        {
            return _graphics.PreferredBackBufferWidth = _graphics.GraphicsDevice.Viewport.Width;
        }
    }

    public static void Initialize()
    {
        saveManager = new XmlManager<Saves>();
        _saves = saveManager.Load("../../../src/xml/Save.xml");
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
        _currentScore += score;
        return score;
    }
    public static void RestartLevel()
    {
        _currentGameplay.RestartLevel();
    }

    public static void Save()
    {
        if (_currentPlayer != String.Empty)
        {
            _saves.addSave(_currentPlayer,_currentScore,_currentLevelId,DateTime.Now);
        }
        else
        {
            _saves.addSave("Anonyme",_currentScore,_currentLevelId,DateTime.Now);
        }
        
        saveManager.Save("../../../src/xml/Save.xml",_saves,new XmlSerializerNamespaces());
        XMLUtils.XslTransform("../../../src/xml/Save.xml","../../../src/xslt/Save.xsl","../../../src/html/hiScores.html");
    }
    
    
    

}