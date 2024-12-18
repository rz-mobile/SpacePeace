using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Sprite _ship;
    private Tile _testTile;
    private Texture2D _tileTest;
    private bool _levelBegan = false;
    private int _wTest = 500;

    private int _hTest = 500;
    private Gameplay _gameplay;
    private Mainmenu _mainmenu;
    bool _isPlaying {get => Utils._isPlaying;set => Utils._isPlaying = value;}

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Utils._graphics = _graphics;
        Utils._content = Content;
        Utils._content.RootDirectory = "Content";
        IsMouseVisible = true;
        
    }

    protected override void Initialize() {
        base.Initialize();
        //Utils._currentGame = this;
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _tileTest = Utils._content.Load<Texture2D>("mapForest");
        ;/*
        using (TextReader reader = new StreamReader("../../../src/xml/testSprite.xml"))
        {
            var xmlC = new XmlSerializer(typeof(Sprite));
            _ship = (Sprite)xmlC.Deserialize(reader);
        }*/
        Utils.Initialize();
        XMLUtils.ValidateXmlFileAsync("http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/GameOne","../src/xsd/GameOne.xsd","../src/xml/GameOne.xml");
        XMLUtils.XslTransform("../../../src/xml/GameOne.xml","../../../src/xslt/attributs_du_jeu.xsl","../../../src/html/attributs_du_jeu.html" );
        

    }

    protected override void LoadContent() {
        /*Utils._textures.Add("map",Content.Load<Texture2D>("map"));
        Utils._textures.Add("ship1",Content.Load<Texture2D>("ship1"));
        Utils._textures.Add("ship2",Content.Load<Texture2D>("ship2"));*/
        _gameplay = new Gameplay();
        _mainmenu = new Mainmenu();
        
    }

    protected override void Update(GameTime gameTime) {
        if (!_isPlaying)
        {
            _levelBegan = false;
            _mainmenu.Update(gameTime);
            if (_mainmenu.StartGame){
                _isPlaying = true;
            }
            if (_mainmenu.ExitGame){
                Exit();
            }
        }
        else
        {
            if (!_levelBegan)
            {
                _gameplay = new Gameplay();
                _levelBegan = true;
            }
            _gameplay.Update(gameTime);
        }
        
        
        base.Update(gameTime);
        
        
    }

    protected override void Draw(GameTime gameTime) {

        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        if (!_isPlaying)
        {
            _mainmenu.Draw(_spriteBatch);
        }
        else
        {
            _gameplay.Draw(_spriteBatch);
        }
        //_ship.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);

    }
}