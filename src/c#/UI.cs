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
        _restartButton = new Button("Info_BTN",new Vector2(395,400),50, 150);
        YouLose = new Sprite("YouLose",new Vector2(Utils.screenWidth/2,150),50, 250);
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
                    Saves s = new Saves();
                    s.addSave("test1",50,0);
                    s.addSave("test2",100,15);
                    XmlManager<Saves> sxml = new XmlManager<Saves>();
                    sxml.Save("../../../src/xml/Save.xml",s,new XmlSerializerNamespaces());
                    Utils._isPlaying = false;
                }

                if (_resumeButton._clicked)
                {
                    _paused = !_paused;
                }
            }
            
            if (_restartButton._clicked)
            {
                _paused = !_paused;
                Utils.RestartLevel();
            }
        }
    }

    public void Draw(SpriteBatch spriteBatch,Player p)
    {
        string output = "Health : " + p._ptVie;
        
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