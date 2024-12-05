using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Player : GameObject
{
    int i = 0;
    public bool surSol = false;
    public Vector2 speed;
    private float gravity;
    private bool isJumping = false;
    private float jumpForce;
    public Rectangle bottomHitbox {get => new Rectangle((int)_position.X-(_size/2)+6, (int)_position.Y+(_size/2), _size-12, 4);}
    public Rectangle rightHitbox{get => new Rectangle((int)_position.X+(_size/2), (int)_position.Y-(_size/2)+3, 4, _size-6);}
    public Rectangle leftHitbox{get => new Rectangle((int)_position.X - (_size/2), (int)_position.Y-(_size/2)+3, 4, _size-6);}
    public Rectangle topHitbox{get => new Rectangle((int)_position.X-(_size/2)+6, (int)_position.Y-(_size/2), _size-12, 4);}
    public bool rWall = false;
    public bool lWall = false;
    private int _size;
    private int ptVie;

    public void setGravity(float gravity)
    {
        // rajouter les contraintes de map
        //todo
        this.gravity = gravity;
    }
    public Player(string texture, Vector2 _position, int size) : base(texture, _position, size)
    {
        speed = new Vector2(0.0f, 0.0f);
        jumpForce = 5.0f;
        gravity = 0.1f;
        ptVie = 10;
        _size = size;

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

        i++;
        if (!surSol)
        {
            speed = new Vector2(speed.X, speed.Y+gravity);
        }


        speed.X = 0;
        //Console.WriteLine(_position +":" +speed);
        /*if (rWall || lWall)
        {
            speed.X -= 2 * speed.X;
        }*/
        if (Keyboard.GetState().IsKeyDown(Keys.Right) && !rWall)
        {
            speed.X = 10.0f;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left) && !lWall)
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

        _position = new Vector2(_position.X, _position.Y + speed.Y);

        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        rect.SetData(new Color[] { Color.White });
        //spriteBatch.Draw(rect,_Rect, Color.Black);
        spriteBatch.Draw(rect,leftHitbox, Color.White);
        spriteBatch.Draw(rect,rightHitbox, Color.Blue);
        spriteBatch.Draw(rect,bottomHitbox, Color.Red);
        spriteBatch.Draw(rect,topHitbox, Color.Green);
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