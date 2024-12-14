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
    int _timer = 0;
    public bool _surSol = false;
    bool _tirPresse = false;
    public Vector2 _speed;
    private float _gravity;
    private bool _isJumping = false;
    [XmlElement("jumpForce")] public float _jumpForce{get;private set;}
    public Rectangle _bottomHitbox {get => new Rectangle((int)Position.X-(Width/2)+6, (int)Position.Y+(Height/2), Width-12, 4);}
    public Rectangle _rightHitbox{get => new Rectangle((int)Position.X+(Width/2), (int)Position.Y-(Height/2)+3, 4, Height-6);}
    public Rectangle _leftHitbox{get => new Rectangle((int)Position.X - (Width/2), (int)Position.Y-(Height/2)+3, 4, Height-6);}
    public Rectangle _topHitbox{get => new Rectangle((int)Position.X-(Width/2)+6, (int)Position.Y-(Height/2), Width-12, 4);}
    public bool _rWall = false;
    public bool _lWall = false;
    [XmlElement("ptVie")]public int _ptVie { get;private set; }
    private int _maxTimer = 200;
    private bool _unvulnerable = false;
    public int _vies;
    private List<Shoot> tirList = new List<Shoot>();
    private Shoot shooter;
    private static System.Timers.Timer temps;
    
    public Player(string texture, Vector2 position, int size) : base(texture, position, size, 3,7)
    {
        _speed = new Vector2(0.0f, 0.0f);
        _jumpForce = 5.0f;
        _gravity = 0.1f;
        _ptVie = 10;

    }

    public Player():base()
    {
        _speed = new Vector2(0.0f, 0.0f);
        _gravity = 0.1f;
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
    public void Initialize(){}
    
    public new void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        
        
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
            _speed.X = 10.0f;
        }else if (Keyboard.GetState().IsKeyDown(Keys.Left) && !_lWall)
        {
            _speed.X = -10.0f;
        }
        
        
        if (Keyboard.GetState().IsKeyDown(Keys.Down) )
        {
            if (!_tirPresse)
            {
                tirList.Add(new Shoot("ship1", Position, 50));
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
            tir.Update(gameTime);
        }
        
        
        if (Keyboard.GetState().IsKeyDown(Keys.Up))
        {
            Jump();
        }
        
        
        if (tomber())
        {
            if (_ptVie >=0)
            {
                _ptVie -= 2;
                _speed = new Vector2(0, 0);
                Position = new Vector2(100, 100);
            }

        }

        Position = new Vector2(Position.X, Position.Y + _speed.Y);

        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if ((_timer % 4)==0)
        {
            base.Draw(spriteBatch, new Rectangle()); // TODO
        }
        Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
        rect.SetData(new Color[] { Color.White });
        spriteBatch.Draw(rect,_leftHitbox, Color.Yellow);
        spriteBatch.Draw(rect,_rightHitbox, Color.Blue);
        spriteBatch.Draw(rect,_bottomHitbox, Color.Red);
        spriteBatch.Draw(rect,_topHitbox, Color.Green);
        foreach (var tir in tirList)
        {
            tir.Draw(spriteBatch);
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
            //Console.WriteLine("ouch!");
            _timer = 0;
            _ptVie -= degats;
            _unvulnerable = true;
        }
    }
    public bool tomber()
    {
        bool result = false;
        if (Position.Y >1000) { result = true; }
        return result;
    }

    public void tire()
    {
        temps = new System.Timers.Timer(300);
        temps.Elapsed += (sender, e) =>
        {
            // Action à exécuter après 300 ms
            Texture2D shipTexture = Utils._content.Load<Texture2D>("ship1");
            //float pos_X = Position.X;
            //float pos_Y = Position.Y;

            //tirList.Add(new Shoot("ship1", new Vector2(pos_X / 2, pos_Y / 2), 20));
            temps.Stop();
            temps.Dispose();
        };

        temps.AutoReset = false; 
        temps.Enabled = true;

    }
    
}