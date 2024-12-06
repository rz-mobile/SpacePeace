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
    private Player _player;
    private Tilemap _tileMapTest;
    private CollisionMap _collisionMapTest;
    
    private XmlDocument _doc;
    private XmlNode _root;
    private XmlNamespaceManager _nsmgr;
    
    private Texture2D _texture;
    public Camera _camera;
    
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
        _player = new Player("ship2",new Vector2(300,150), 50);
        


    }

    public void Update(GameTime gameTime)
    {
        Vector2 offset = _camera.moveCamera(_player._speed);
        if (offset != Vector2.Zero)
        {
            _tileMapTest.setOffset(offset);
            _collisionMapTest.setOffset(offset);
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
        _player.Update(gameTime);
        _tileMapTest.Update(gameTime);

        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        _tileMapTest.Draw(spriteBatch);
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