using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Sprite _ship;
    //private level lv;
    //private Player _player;
    private Tile testTile;
    private Texture2D tileTest;

    private int wTest = 500;

    private int hTest = 500;
    //private Camera _camera;
    private Gameplay gameplay;

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Utils._graphics = _graphics;
        Utils._content = Content;
        Utils._content.RootDirectory = "Content";
        IsMouseVisible = true;
        //_camera = new(Vector2.Zero);
    }

    protected override void Initialize() {
        base.Initialize();
    }

    protected override void LoadContent() {
        Utils._currentGame = this;
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D shipTexture = Utils._content.Load<Texture2D>("ship2");
        Texture2D ship2Texture = Utils._content.Load<Texture2D>("ship1");
        tileTest = Utils._content.Load<Texture2D>("map");
        //_player = new Player(ship2Texture,new Vector2(100,100), 20);
        //_ship = new Sprite(tileTest, new Vector2(300, 150),100);
        //testTile = new Tile(300, 150, "17",tileTest);
        Texture2D mapTexture = Utils._content.Load<Texture2D>("map");
        //lv = new level("../../../src/xml/map.xml",mapTexture,shipTexture,_graphics.GraphicsDevice);
        gameplay = new Gameplay();
    }

    protected override void Update(GameTime gameTime) {
        //Console.WriteLine("Game Time: " + gameTime.ElapsedGameTime.TotalMilliseconds);
        /*if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();*/
        //_player.Update(gameTime);
        //lv.Update(gameTime);
        gameplay.Update(gameTime);
        /*if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            _ship.setPosition(new Vector2(_ship._position.X + 10, _ship._position.Y));
            wTest+= 10;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            _ship.setPosition(new Vector2(_ship._position.X - 10, _ship._position.Y));
            wTest -= 10;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            _ship.setPosition(new Vector2(_ship._position.X, _ship._position.Y + 10));
            hTest += 10;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            _ship.setPosition(new Vector2(_ship._position.X, _ship._position.Y - 10));
            hTest -= 10;
        }
        testTile.Update(gameTime);*/
        //_camera.Follow(_player._Rect , new Vector2(_graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight));
        
        base.Update(gameTime);

        //if (_player != null)
        //{
            //_player.Update(gameTime);
            //if (_player.ptVie <= 0)
            //{
              //  _player = null;
            //    Console.WriteLine("Le joueur à été supprimé ");
          //  }
        //}
        
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        gameplay.Draw(_spriteBatch);
        //lv.Draw(_spriteBatch);
        //_player.Draw(_spriteBatch);
        //testTile.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}