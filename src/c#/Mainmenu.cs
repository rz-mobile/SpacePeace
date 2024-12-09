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

    //SpriteBatch _spriteBatch;
    
    public bool StartGame { get; private set; }
    public bool ExitGame { get; private set; }
    
    Button _playButton;
    Button _exitButton;
    
    public Mainmenu(){
        _main = new UI();
        //_level1 = new Level("../../../src/xml/Level1.xml", Utils._graphics.GraphicsDevice);
        _graphicsDevice  = Utils._graphics.GraphicsDevice;
        _font =  Utils._content.Load<SpriteFont>("MyMenuFont");
        _playButton = new Button("ship1", new Vector2(200, 300), 100);
        _exitButton = new Button("ship2", new Vector2(500, 300), 100);
        StartGame = false;
        ExitGame = false;
    }

    public void Update(GameTime gameTime){
        _graphicsDevice.Clear(Color.Blue);
        if (_playButton.Clicked())
        {
            // le jeu commence
            StartGame = true;
            
            //_level1.Update(gameTime);
            
        }

        if (_exitButton.Clicked())
        {
            ExitGame = true;
        }

    }

    public void Draw(SpriteBatch spriteBatch){
        //_level1.Draw(spriteBatch);
        
        _playButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);
        spriteBatch.DrawString(_font, "MENU PRINCIPAL", new Vector2(300,20), Color.White);

        spriteBatch.DrawString(_font,"Commencer",new Vector2(150, 300), Color.White );
        spriteBatch.DrawString(_font,"Quitter",new Vector2(470, 300), Color.White );
    }
    
    
} 