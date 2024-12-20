﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Mainmenu
{
 
    private bool keyPressed = false;
    
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
    Sprite _echap;
    Sprite _espace;
    
    // touche pour le tuto
    private Sprite _fondTuto;
    private Sprite _infoTuto;
    private Sprite _cloudPause;
    private Sprite _arrowUp;
    private Sprite _arrowDown;
    private Sprite _arrowLeft;
    private Sprite _arrowRight;
    private Sprite _arrow1;
    private Sprite _arrow2;
    
    
    //Constructeur Vide
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
        
        // tuto
        _fondTuto = new Sprite("BG", new Vector2(400,400), 1000, 1000);
        _infoTuto = new Sprite("unnamed1", new Vector2(700, 50), 50, 50);
        _cloudPause = new Sprite("Cloud_02", new Vector2(400,250), 300, 380);
        _arrowRight = new Sprite("unnamed", new Vector2(482,180), 70, 70);
        _arrowUp = new Sprite("arrowUp", new Vector2(400,180), 70, 70);
        _arrowLeft = new Sprite("unnamed2", new Vector2(322,180), 70, 70);
        
        _arrow1 =  new Sprite("arrow", new Vector2(315,200), 70, 70);
        _arrow2 = new Sprite("arrow2", new Vector2(322,230), 70, 70);
        _echap =  new Sprite("button_echap", new Vector2(330,270), 50, 75);
        _espace = new Sprite("button_espace", new Vector2(330,315), 50, 75);
        
        Utils._currentPlayer = String.Empty;
        
    }

    //Fontion Update prend un GameTime en entrée et ne renvoie rien.
    //Cette fonction permet de mettre à jour le menu.
    public void Update(GameTime gameTime){
        _playButton.Update(gameTime);
        _tutoButton.Update(gameTime);
        _exitButton.Update(gameTime);
        _graphicsDevice.Clear(Color.Blue);
        if (_playButton._clicked)
        {
            // le jeu commence
            StartGame = true;
        }

        if (_exitButton._clicked)
        {
            ExitGame = true;
        }

        if (Keyboard.GetState().GetPressedKeys().Length != 0)
        {
            if (keyPressed == false)
            {
                keyPressed = true;
                if (Keyboard.GetState().GetPressedKeys()[0] >= Keys.A &&
                    Keyboard.GetState().GetPressedKeys()[0] <= Keys.Z)
                {
                    Utils._currentPlayer += Keyboard.GetState().GetPressedKeys()[0];
                }
            }

        }
        else
        {
            keyPressed = false;
        }


    }

    //méthode Draw qui prend un SpriteBatch en entrée et qui ne renvoie rien.
    //Cette méthode permet de dessiner le menu
    public void Draw(SpriteBatch spriteBatch){
        _fond.Draw(spriteBatch);
        _window.Draw(spriteBatch);
        _title.Draw(spriteBatch);
        _tutoButton.Draw(spriteBatch);
        _playButton.Draw(spriteBatch);
        _exitButton.Draw(spriteBatch);
        spriteBatch.DrawString(_font, "NOM : " +Utils._currentPlayer, new Vector2(Utils.screenWidth/4,(Utils.screenHeight/8)+10), Color.White);
        

        if (_tutoButton._clicked)
        {
            _fondTuto.Draw(spriteBatch);
            _infoTuto.Draw(spriteBatch);
            _cloudPause.Draw(spriteBatch);
            _arrowRight.Draw(spriteBatch);
            _arrowLeft.Draw(spriteBatch);
            _arrowUp.Draw(spriteBatch);
            _echap.Draw(spriteBatch);
            _espace.Draw(spriteBatch);
            spriteBatch.DrawString(_font, "Avancer", new Vector2(450,215), Color.White);
            spriteBatch.DrawString(_font, "Reculer", new Vector2(290,215), Color.White);
            spriteBatch.DrawString(_font, "Sauter", new Vector2(380,215), Color.White);
            spriteBatch.DrawString(_font, "Tirer", new Vector2(380,260), Color.White);
            spriteBatch.DrawString(_font, "Mettre en Pause", new Vector2(380,300), Color.White);
            
        }
        
    }
    
    
} 