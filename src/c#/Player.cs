using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;
[XmlRoot("Player", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/gameObjects")]
[Serializable]
public class Player : GameObject
{
    private int[] tabFrame = {2,14,9,7};
    int _timer = 0;
    public bool _surSol = false;
    bool _tirPresse = false;
    public Vector2 _positionBase { get; init; }
    public Vector2 _speed;
    private float _gravity;
    private bool _isJumping = false;
    [XmlElement("jumpForce")] public float _jumpForce{get;private set;}
    public Rectangle _bottomHitbox {get => new Rectangle((int)_position.X-(Width/2)+6, (int)_position.Y+(Height/2), Width-12, 4);}
    public Rectangle _rightHitbox{get => new Rectangle((int)_position.X+(Width/2), (int)_position.Y-(Height/2)+3, 4, Height-6);}
    public Rectangle _leftHitbox{get => new Rectangle((int)_position.X - (Width/2), (int)_position.Y-(Height/2)+3, 4, Height-6);}
    public Rectangle _topHitbox{get => new Rectangle((int)_position.X-(Width/2)+6, (int)_position.Y-(Height/2), Width-12, 4);}
    public bool _rWall = false;
    public bool _lWall = false;
    private int ptVie;
    [XmlElement("ptVie")]
    
    public int _ptVie
    {
        get => ptVie;
        set
        {
            if (value < 0)
            {
                ptVie = 0;
            }
            else
            {
                ptVie = value;
            }
        }
    }

    private int _maxTimer = 60;
    private bool _unvulnerable = false;
    public int _vies;
    public List<Shoot> tirList = new List<Shoot>();
    private Shoot shooter;
    private static System.Timers.Timer temps;
    private SpriteEffects _flip;
    
    public Player(string texture, Vector2 position, int size) : base(texture, position, size, 3,7)
    {
        _positionBase = position;
        _speed = new Vector2(0.0f, 0.0f);
        _jumpForce = 3.5f;
        _gravity = 0.1f;
        _ptVie = 10;

    }

    public Player():base()
    {
        _speed = new Vector2(0.0f, 0.0f);
        _gravity = 0.1f;
    }

    public void setGravity(float gravity)
    {
        _gravity = gravity;
    }
    public void groundReaction()
    {
        _surSol = true;
        _speed = new Vector2(_speed.X, 0.0f);
    }

    public void shootOffset(Vector2 offset)
    {
        foreach (Shoot tir in tirList)
        {
            tir.setOffset(offset);
        }
    }

    public new void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (_ptVie <= 0)
        {
            Utils._paused = true;
            Utils._gameOver = true;
        }
        if (_timer >= _maxTimer)
        {
            _unvulnerable = false;
        }
        if(_unvulnerable)
        {
            _timer++;
        }
        if (!_surSol)
        {
            _speed = new Vector2(_speed.X, _speed.Y+_gravity);
        }
        
        _speed.X = 0;
        if (Keyboard.GetState().IsKeyDown(Keys.Right) && !_rWall)
        {
            _speed.X = 2.0f;
            base.Update(gameTime, 2,tabFrame[1]);
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left) && !_lWall)
        {
            _speed.X = -2.0f;
            
        }
        
        
        if (Keyboard.GetState().IsKeyDown(Keys.Space) )
        {
            if (!_tirPresse)
            {
                tirList.Add(new Shoot("Missile", _position, 30));
                tire();
                _tirPresse = true;
            }
        }
        else
        {
            _tirPresse = false;
            
        }

        foreach (Shoot tir in tirList)
        {
            if (!tir.Detruit)
            {
                tir.Update(gameTime);
            }
        }
         
        
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            Jump();
        }
        
        
        if (tomber())
        {
            damage(2);
            if (_ptVie >0)
            {
                _speed = new Vector2(0, 0);
                _position = _positionBase;
            }

        }

        if (Keyboard.GetState().IsKeyDown(Keys.Right))
        {
            base.Update(gameTime, 1, tabFrame[1]);
            _flip = SpriteEffects.None;
                
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left))
        {
            base.Update(gameTime, 1,tabFrame[1]);
            _flip = SpriteEffects.FlipHorizontally;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            base.Update(gameTime, 2,tabFrame[2]);
        }else if (Keyboard.GetState().IsKeyDown(Keys.Down))
        {
            base.Update(gameTime, 3,tabFrame[3]);
        }else{
            base.Update(gameTime, 0,tabFrame[0]);
        }
        _position = new Vector2(_position.X, _position.Y + _speed.Y);

        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if ((_timer % 4)==0)
        {
            base.Draw(spriteBatch, _flip);
        }
        Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        rect.SetData(new Color[] { Color.White });
        spriteBatch.Draw(rect,_leftHitbox, Color.Yellow);
        spriteBatch.Draw(rect,_rightHitbox, Color.Blue);
        spriteBatch.Draw(rect,_bottomHitbox, Color.Red);
        spriteBatch.Draw(rect,_topHitbox, Color.Green);
        foreach (var tir in tirList)
        {
            if (!tir.Detruit)
            {
                tir.Draw(spriteBatch);
            }
        }
    }

    public void Jump()
    {
        if (_surSol)
        {
            //Console.Write("jump");
            _speed.Y = -_jumpForce;

        }
    }

    public void damage(int degats)
    {
        if (!_unvulnerable)
        { 
            _timer = 0;
            _ptVie -= degats;
            _unvulnerable = true;
        }
    }
    public bool tomber()
    {
        bool result = false;
        if (_position.Y >1000) { result = true; }
        return result;
    }

    public void tire()
    {
        temps = new System.Timers.Timer(300);
        temps.Elapsed += (sender, e) =>
        {
            // Action à exécuter après 300 ms
            Texture2D shipTexture = Utils._content.Load<Texture2D>("Missile");

            temps.Stop();
            temps.Dispose();
        };

        temps.AutoReset = false; 
        temps.Enabled = true;

    }
    
}