using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Player : GameObject
{
    public bool surSol = false;
    private Vector2 speed;
    private float gravity;
    private bool isJumping = false;
    private float jumpForce;
    public Rectangle bottomHitbox;
    public Rectangle rightHitbox;
    public Rectangle leftHitbox;
    public Rectangle topHitbox;
    
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
        rightHitbox = new Rectangle((int)_position.X + size, (int)_position.Y, 1, size);
        leftHitbox = new Rectangle((int)_position.X - 1, (int)_position.Y, 1, size);
        topHitbox = new Rectangle((int)_position.X, (int)_position.Y - 1, size, 1);
        bottomHitbox = new Rectangle((int)_position.X , (int)_position.Y + size, size, 1);
    }

    public void groundReaction()
    {
        //Console.WriteLine("touché");
        surSol = true;
        speed = new Vector2(speed.X, 0.0f);
    }
    public void Initialize(){}
    
    public new void Update(GameTime gameTime)
    {
        rightHitbox.X = (int)_position.X;
        rightHitbox.Y = (int)_position.Y;
        leftHitbox.X = (int)_position.X;
        leftHitbox.Y = (int)_position.Y;
        topHitbox.X = (int)_position.X;
        topHitbox.Y = (int)_position.Y;
        bottomHitbox.X = (int)_position.X;
        bottomHitbox.Y = (int)_position.Y;
        if (!surSol)
        {
            speed = new Vector2(speed.X, speed.Y+gravity);
        }

        speed.X = 0;
        Console.WriteLine(_position +":" +speed);
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
        if (surSol)
        {
            //surSol = false;
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