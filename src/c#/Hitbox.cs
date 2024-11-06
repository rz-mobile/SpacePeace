using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SpacePeace;

public class Hitbox
{
    //private Texture2D _texture;
    protected Vector2 _position;
    private int _size = 100;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    List<Sprite> sprites;
    private Sprite PlayerSprite;
    private Rectangle _Rect { get => new Rectangle((int) _position.X, (int) _position.Y, _size, _size); }
    
    protected void Initialize() {
    }

    protected void LoadContent() {
        /*_spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D shipTexture = Content.Load<Texture2D>("ship2"); // à changer quand j'aurais le cosmonaute
        PlayerSprite = new Sprite(shipTexture, new Vector2(150, 150), 50); //pos de départ
        sprites.Add(PlayerSprite);*/
    } 

    protected void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            //Exit();
            ;
        List<Sprite> killList = new List<Sprite>();
        foreach (var sprite in sprites)
        {
            sprite.Update(gameTime);
            if ( sprite != PlayerSprite && sprite._Rect.Intersects(PlayerSprite._Rect))
            {
                killList.Add(sprite);
            } ;
           
        }
        foreach (var sprite in killList)
        {
                sprites.Remove(sprite);
        }
        //base.Update(gameTime);
    }

    protected void Draw(GameTime gameTime) {
        /*GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        _ship.Draw(_spriteBatch);
        _spriteBatch.End();
        base.Draw(gameTime); */
    }
}