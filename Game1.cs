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
    private Tile _testTile;
    private Texture2D _tileTest;

    private int _wTest = 500;

    private int _hTest = 500;
    private Gameplay _gameplay;

    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        Utils._graphics = _graphics;
        Utils._content = Content;
        Utils._content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        base.Initialize();
    }

    protected override void LoadContent() {
        Utils._currentGame = this;
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D shipTexture = Utils._content.Load<Texture2D>("ship2");
        Texture2D ship2Texture = Utils._content.Load<Texture2D>("ship1");
        _tileTest = Utils._content.Load<Texture2D>("map");
        Texture2D mapTexture = Utils._content.Load<Texture2D>("map");
        _gameplay = new Gameplay();
    }

    protected override void Update(GameTime gameTime) {
        
        _gameplay.Update(gameTime);
        
        
        base.Update(gameTime);
        
        
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _gameplay.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}