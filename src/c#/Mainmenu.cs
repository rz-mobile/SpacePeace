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
    Button _tutoButton;
    
    public Mainmenu(){
        _main = new UI();
        _graphicsDevice  = Utils._graphics.GraphicsDevice;
        _font =  Utils._content.Load<SpriteFont>("MyMenuFont");
        _playButton = new Button("Start_BTN", new Vector2(300, 300), 50, 150);
        _exitButton = new Button("Exit_BTN", new Vector2(510, 300), 50, 150);
        _tutoButton = new Button("unnamed1", new Vector2(700, 50), 50, 50);
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
        _tutoButton.Draw(spriteBatch);
        _playButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);
        
        /*
         private Sprite _cloudPause;
         private Sprite _arrowUp;
         private Sprite _arrowDown;
         private Sprite _arrowLeft;
         private Sprite _arrowRight;
         
         
         _cloudPause = new Sprite("Cloud_02", new Vector2(400,250), 380, 450);
        _arrowDown = new Sprite("unnamed3", new Vector2(400,250), 380, 450);
        _arrowLeft = new Sprite("unnamed", new Vector2(400,250), 380, 450);
        _arrowUp = new Sprite("unnamed1", new Vector2(400,250), 380, 450);
        _arrowRight = new Sprite("unnamed2", new Vector2(400,250), 380, 450);
        
        _cloudPause.Draw(spriteBatch);
        _arrowRight.Draw(spriteBatch);
        _arrowLeft.Draw(spriteBatch);
        
        */
        
    }
    
    
} 