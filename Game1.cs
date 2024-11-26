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
    private level lv;
    private Player _player;
    private Tile testTile;
    private Camera _camera;

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        //_camera = new(Vector2.Zero);
    }

    protected override void Initialize() {
        base.Initialize();
    }

    protected override void LoadContent() {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D shipTexture = Content.Load<Texture2D>("ship2");
        Texture2D ship2Texture = Content.Load<Texture2D>("ship1");
        Texture2D TileTest = Content.Load<Texture2D>("map");
        _player = new Player(ship2Texture,new Vector2(100,100), 20);
        _ship = new Sprite(shipTexture, new Vector2(300, 150),100);
        //testTile = new Tile(300, 150, "17",TileTest);
        Texture2D mapTexture = Content.Load<Texture2D>("map");
        lv = new level("/home/r/Documents/travail/XML/SpacePeace/src/xml/map.xml",mapTexture);
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        _player.Update(gameTime);
        lv.Update(gameTime);
        //testTile.Update(gameTime);
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
        lv.Draw(_spriteBatch);
        _ship.Draw(_spriteBatch);
        //_player.Draw(_spriteBatch);
        //testTile.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}