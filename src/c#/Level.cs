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
    public Camera Camera;
    
    private List<string[]> _map;

    private List<Tile> _tiles;
    public Level(String path ,GraphicsDevice graphicsDevice)
    {
        Camera = new Camera(new Vector2(0.0f, 0.0f));
        
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
        Enemy _enemy = new Enemy("player", new Vector2(400, 150), 50,1);
        Enemy _enemy2 = new Enemy("player", new Vector2(550, 150), 100,1);
        _enemies.Add(_enemy);
        _enemies.Add(_enemy2);
        _player = new Player();
        


    }

    public void Update(GameTime gameTime)
    {
        Vector2 offset = Camera.moveCamera(_player._speed);
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
            if (_collisionMapTest.CheckCollision(e.Rect))
            {
                e.groundReaction();
            }

            if (!e.Dead)
            {
                e.Update(gameTime);
                if (e.checkTopCollision(_player._bottomHitbox))
                {
                    e.die();
                    _player._speed.Y = -_player._jumpForce;
                }else if (e.checkCollision(_player.Rect))
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
        _tileMapTest.Draw(spriteBatch);
        foreach (Enemy e in _enemies)
        {
            if (!e.Dead)
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