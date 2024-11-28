using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Player : GameObject
{
    private Vector2 speed;
    private float gravity;
    private bool isJumping = false;
    private float jumpForce;
    private int ptVie;

    public void setGravity(float gravity)
    {
        // rajouter les contraintes de map
        //todo
        this.gravity = gravity;
    }
    public Player(Texture2D texture, Vector2 _position, int size) : base(texture, _position, size)
    {
        speed = new Vector2(0.0f, 0.0f);
        jumpForce = 5.0f;
        gravity = 0.1f;
        ptVie = 10;
    }
    public void Initialize(){}
    
    public new void Update(GameTime gameTime)
    {
        speed = new Vector2(0.0f, speed.Y+gravity);
        Console.WriteLine(_position);
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            speed.X = 10.0f;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            speed.X = -10.0f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            //speed.Y = 10.0f+gravity/2.0f;
            
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            Jump();
            /*speed.Y -= 1.0f;
            speed.X += 1.0f;*/
        }

        _position = new Vector2(_position.X + speed.X, _position.Y + speed.Y);

        
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            /*
            if (speed.Y > 0)
            {
                _position = new Vector2(_position.X-speed.X, _position.Y + speed.Y);

            }
            else
            {
                _position = new Vector2(_position.X + speed.X, _position.Y - speed.Y);
                
            }

            speed.Y += 0.1f;*/
            speed.Y = -jumpForce;

        }
        /*else
        {
            speed.X = 0.0f;
            speed.Y = 0.0f;
        }  */      
    }

    
    /*public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }*/
    
    
}