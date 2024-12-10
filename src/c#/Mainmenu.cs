using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Mainmenu
{
    
    private UI _main;
    private Level _level1;
    private GraphicsDevice _graphicsDevice;
    SpriteFont _font;
    private Sprite _window;
    private Sprite _fond; 
    Sprite _title;
    
    public bool StartGame { get; private set; }
    public bool ExitGame { get; private set; }
    
    Button _playButton;
    Button _exitButton;
    
    public Mainmenu(){
        _main = new UI();
        _graphicsDevice  = Utils._graphics.GraphicsDevice;
        _font =  Utils._content.Load<SpriteFont>("MyMenuFont");
        _playButton = new Button("Start_BTN", new Vector2(300, 300), 50, 150);
        _exitButton = new Button("Exit_BTN", new Vector2(510, 300), 50, 150);
        StartGame = false;
        ExitGame = false;
        _window = new Sprite("Window", new Vector2(400,250), 380, 450);
        _fond = new Sprite("BG", new Vector2(400,400), 1000, 1000);
        _title = new Sprite("titre1", new Vector2(400,170), 40, 230);
    }

    public void Update(GameTime gameTime){
        _graphicsDevice.Clear(Color.Blue);
        if (_playButton.Clicked())
        {
            // le jeu commence
            StartGame = true;
        }

        if (_exitButton.Clicked())
        {
            ExitGame = true;
        }
    }

    public void Draw(SpriteBatch spriteBatch){
        _fond.Draw(spriteBatch);
        _window.Draw(spriteBatch);
        _title.Draw(spriteBatch);
        _playButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);
        //spriteBatch.DrawString(_font, "MENU PRINCIPAL", new Vector2(330,20), Color.White);
    }
    
    
} 