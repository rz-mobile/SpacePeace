using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Player : GameObject
{
    Vector2 speed = new Vector2(0.0f, 0.0f);
    Vector2 position = _position ;
    private float gravity;
    private bool isJumping;
    protected double ptVie;
    private int w;
    private int h;
    private int windowWidth;
    private int windowHeight;
    public void setGravity(float gravity)
    {
        // rajouter les contraintes de map
        //todo
        this.gravity = gravity;
    }
    public Player(Texture2D texture, Vector2 position, int size) : base(texture, position, size)
    {
    }
    public void Initialize(){ 
        setGravity(1.0f);
        w = windowWidth;
        h = windowHeight;
        ptVie = 5;
    }
    
    public new void Update(GameTime gameTime)
    {

        position = new Vector2(position.X + speed.X, position.Y + speed.Y);
        speed.Y = gravity;
        gravity = 10;
        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            speed.X = 10.0f;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            speed.X = -10.0f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            speed.Y = 10.0f+gravity/2.0f;
            
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            Jump();
            speed.Y -= 1.0f;
            speed.X += 1.0f;
        }

        _position.X += speed.X;
        _position.Y += speed.Y;

        
    }

    public void Jump()
    {
        if (isJumping)
        {

            if (speed.Y > 0)
            {
                
                _position.Y += speed.Y;
                _position.X -= speed.X;
            }
            else
            {
                _position.Y -= speed.Y;
                _position.X += speed.X;
                
            }

            speed.Y += 0.1f;
        }
        else
        {
            speed.X = 0.0f;
            speed.Y = 0.0f;
        }        
    }
    protected override void Draw(SpriteBatch spriteBatch)
    {
        throw new System.NotImplementedException();
    }

    private void estMort()
    {
        if (_position.X > w && _position.X < 0 && _position.Y > h && _position.Y < 0)
        {
            ptVie = 0;
            Console.WriteLine("Le joeur est mort");
            //Texture=null ; détruire l'intence du playeur 
        }
        
    }


    /**
    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }**/
}