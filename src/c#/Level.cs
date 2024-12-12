using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class Level
{
    public Player _player { get; private set; }
    private Tilemap _tileMapTest;
    private CollisionMap _collisionMapTest;
    private List<Enemy> _enemies;
    
    private XmlDocument _doc;
    private XmlNode _root;
    private XmlNamespaceManager _nsmgr;
    
    private Texture2D _texture;
    public Camera _camera;

    private Sprite _fond;
    private Sprite _elmtFond;
    private Sprite _meteorFond1;
    private Sprite _meteorFond2;
    private Sprite _meteorFond3;
    private Sprite _meteorFond4;
    private Sprite _meteorFond5;
    private Sprite _meteorFond6;
    private Sprite _meteorFond7;
    
    
    private List<string[]> _map;

    private List<Tile> _tiles;
    public Level(String path ,GraphicsDevice graphicsDevice)
    {
        _camera = new Camera(new Vector2(0.0f, 0.0f));
        
        _map = new List<string[]>();
        _tiles = new List<Tile>();
        
        _doc = new XmlDocument();
        String currentLevel = xmlMap(path);
        _tileMapTest = new Tilemap(currentLevel);
        _collisionMapTest = new CollisionMap(currentLevel,_texture,graphicsDevice);
        /*
        using (TextReader reader = new StreamReader("../../../src/xml/Player.xml"))
        {
            var xmlC = new XmlSerializer(typeof(Player));
            _player = (Player)xmlC.Deserialize(reader);
        }
        */
        
        _enemies = new List<Enemy>();
        Enemy _enemy = new Enemy("ship1", new Vector2(400, 150), 50,1);
        Enemy _enemy2 = new Enemy("ship1", new Vector2(550, 150), 100,1);
        _enemies.Add(_enemy);
        _enemies.Add(_enemy2);
        _player = new Player("ship2",new Vector2(300,150), 50);
        
       _fond = new Sprite("fond", new Vector2(400,400), 1000, 1000);
       _elmtFond = new Sprite("Bomb_1_Explosion_005", new Vector2(600,150), 80, 80);
       _meteorFond1 = new Sprite("Meteor_01", new Vector2(300,200), 50, 70);
       _meteorFond2 = new Sprite("Meteor_02", new Vector2(150,50), 40, 60);
       _meteorFond3 = new Sprite("Meteor_03", new Vector2(400,60), 60, 70);
       _meteorFond4 = new Sprite("Meteor_04", new Vector2(230,80), 20, 30);
       _meteorFond5 = new Sprite("Meteor_04", new Vector2(680,250), 60, 70);
       _meteorFond6 = new Sprite("Meteor_03", new Vector2(80,300), 40, 55);
       _meteorFond7 = new Sprite("Meteor_02", new Vector2(700,40), 30, 50);
       
        
    }

    public void Update(GameTime gameTime)
    {
        Vector2 offset = _camera.moveCamera(_player._speed);
        _player.shootOffset(offset);
        if (offset != Vector2.Zero)
        {
            _tileMapTest.setOffset(offset);
            _collisionMapTest.setOffset(offset);
            foreach (Enemy e in _enemies)
            {
                e.setOffset(offset);
            }
        }
        if (_collisionMapTest.CheckCollision(_player._rightHitbox))
        {
            _player._rWall = true;
        }
        else
        {
            _player._rWall = false;
        }
        if (_collisionMapTest.CheckCollision(_player._leftHitbox))
        {
            _player._lWall = true;
        }
        else
        {
            _player._lWall = false;
        }
        if (_collisionMapTest.CheckCollision(_player._bottomHitbox))
        {
            _player.groundReaction();
        }
        else
        {
            _player._surSol = false;
        }

        foreach (Enemy e in _enemies)
        {
            if (_collisionMapTest.CheckCollision(e._rect))
            {
                e.groundReaction();
            }

            if (!e._dead)
            {
                e.Update(gameTime);
                if (e.checkTopCollision(_player._bottomHitbox))
                {
                    e.die();
                    _player._speed.Y = -_player._jumpForce;
                }else if (e.checkCollision(_player._rect))
                {
                    _player.damage(e._degats);
                }
            }
        }

        _player.Update(gameTime);
        _tileMapTest.Update(gameTime);

        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        
        _fond.Draw(spriteBatch);
        _elmtFond.Draw(spriteBatch);
        _meteorFond1.Draw(spriteBatch);
        _meteorFond2.Draw(spriteBatch);
        _meteorFond3.Draw(spriteBatch);
        _meteorFond4.Draw(spriteBatch);
        _meteorFond5.Draw(spriteBatch);
        _meteorFond6.Draw(spriteBatch);
        _meteorFond7.Draw(spriteBatch);
        
        
        _tileMapTest.Draw(spriteBatch);
        foreach (Enemy e in _enemies)
        {
            if (!e._dead)
            {
                e.Draw(spriteBatch);
            }
        }


        _player.Draw(spriteBatch);
        
    }

    
    public String xmlMap(String xmlPath)
    {
        String map = "";
        _doc.Load(xmlPath);
        XmlNode node = _doc.SelectSingleNode("//data");
       if (node != null)
       {
           map += node.InnerText;
       }
       else
       {
           Console.WriteLine("échec de la création du level on ne trouve pas 'data'.");
       }
       return map;
    }
}