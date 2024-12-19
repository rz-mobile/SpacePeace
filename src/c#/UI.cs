using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class UI
{
    SpriteFont _font;
    private Vector2 _fontPos;
    Button _quitButton;
    Button _resumeButton;
    Button _restartButton;
    private Sprite YouLose;
    public bool ExitGame { get; private set; }
    private bool _paused
    {
        get => Utils._paused;
        set => Utils._paused = value;
    }

    private bool _gameOver
    {
        get => Utils._gameOver;
        set => Utils._gameOver = value;
    }

    public UI()
    {
        _font = Utils._content.Load<SpriteFont>("MyMenuFont");
        _quitButton = new Button("Exit_BTN",new Vector2(550,300),50, 150);
        _resumeButton = new Button("Start_BTN",new Vector2(240,300),50, 150);
        _restartButton = new Button("Replay",new Vector2(355,300),80, 80);
        YouLose = new Sprite("YouLose",new Vector2(Utils.screenWidth/2,150),50, 250);
        _quitButton = new Button("Exit_BTN",new Vector2(510,300),50, 150);
        _resumeButton = new Button("ok",new Vector2(240,300),80, 80);
    }

    public void Update(GameTime gameTime)
    {
        if (_paused)
        {
            _restartButton.Update(gameTime);
            if (!_gameOver)
            {
                _quitButton.Update(gameTime);
                _resumeButton.Update(gameTime);
                if (_quitButton._clicked)
                {
                    Utils.Save();
                    Utils._game1.Exit();
                }

                if (_resumeButton._clicked)
                {
                    _paused = !_paused;
                }
            }
            
            if (_restartButton._clicked)
            {
                _paused = !_paused;
                Utils._currentScore = 0;
                Utils.RestartLevel();
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch,Player p)
    {
        string output = "Health : " + p._ptVie;
        string output2 = "Score : " + Utils._currentScore ;
        
        spriteBatch.DrawString(_font, output2, new Vector2(_fontPos.X,_fontPos.Y+20), Color.White);
        spriteBatch.DrawString(_font, output, _fontPos, Color.White);
        if (_paused)
        {
            if (_gameOver)
            {
                YouLose.Draw(spriteBatch);
            }
            else
            {
                _quitButton.Draw(spriteBatch);
                _resumeButton.Draw(spriteBatch);
            }
            _restartButton.Draw(spriteBatch);
        }
    }
}