using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Player : GameObject
{
    int i = 0;
    public bool _surSol = false;
    public Vector2 _speed;
    private float _gravity;
    private bool _isJumping = false;
    private float _jumpForce;
    public Rectangle _bottomHitbox {get => new Rectangle((int)_position.X-(_size/2)+6, (int)_position.Y+(_size/2), _size-12, 4);}
    public Rectangle _rightHitbox{get => new Rectangle((int)_position.X+(_size/2), (int)_position.Y-(_size/2)+3, 4, _size-6);}
    public Rectangle _leftHitbox{get => new Rectangle((int)_position.X - (_size/2), (int)_position.Y-(_size/2)+3, 4, _size-6);}
    public Rectangle _topHitbox{get => new Rectangle((int)_position.X-(_size/2)+6, (int)_position.Y-(_size/2), _size-12, 4);}
    public bool _rWall = false;
    public bool _lWall = false;
    private int _size;
    private int _ptVie;

    public void setGravity(float _gravity)
    {
        // rajouter les contraintes de map
        //todo
        this._gravity = _gravity;
    }
    public Player(string texture, Vector2 _position, int size) : base(texture, _position, size)
    {
        _speed = new Vector2(0.0f, 0.0f);
        _jumpForce = 5.0f;
        _gravity = 0.1f;
        _ptVie = 10;
        _size = size;

    }

    public void groundReaction()
    {
        _surSol = true;
        _speed = new Vector2(_speed.X, 0.0f);
    }
    
    
    public void Initialize(){}
    
    public new void Update(GameTime gameTime)
    {

        i++;
        if (!_surSol)
        {
            _speed = new Vector2(_speed.X, _speed.Y+_gravity);
        }


        _speed.X = 0;
        if (Keyboard.GetState().IsKeyDown(Keys.Right) && !_rWall)
        {
            _speed.X = 10.0f;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left) && !_lWall)
        {
            _speed.X = -10.0f;
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            //_speed.Y = 10.0f+_gravity/2.0f;
            
        }
        else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            Jump();
        }

        _position = new Vector2(_position.X, _position.Y + _speed.Y);

        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        rect.SetData(new Color[] { Color.White });
        spriteBatch.Draw(rect,_leftHitbox, Color.White);
        spriteBatch.Draw(rect,_rightHitbox, Color.Blue);
        spriteBatch.Draw(rect,_bottomHitbox, Color.Red);
        spriteBatch.Draw(rect,_topHitbox, Color.Green);
    }

    public void Jump()
    {
        if (_surSol)
        {
            _speed.Y = -_jumpForce;

        }
    }
    
}