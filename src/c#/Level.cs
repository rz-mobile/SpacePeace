using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class Level
{
    public Player _player { get; private set; }
    private Tilemap _avantPlan;
    private Tilemap _arrierePlan;
    private CollisionMap _collisionMap;
    private List<Enemy> _enemies;
    
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
        string currentLevelForeGround = xmlMap(path,"AvantPlan");
        _avantPlan = new Tilemap(currentLevelForeGround);
        string currentLevelBackGround = xmlMap(path,"ArrierePlan");
        _arrierePlan = new Tilemap(currentLevelBackGround);
        string currentLevelCollisions = xmlMap(path,"Collision");
        _collisionMap = new CollisionMap(currentLevelCollisions,_texture,graphicsDevice);
        
        /*using (TextReader reader = new StreamReader("../../../src/xml/Player.xml"))
        {
            var xmlC = new XmlSerializer(typeof(Player));
            _player = (Player)xmlC.Deserialize(reader);
        }*/
        
        _enemies = new List<Enemy>();
        List<Vector2> positionsEnnemis = positionEnnemis(path);
        foreach (Vector2 position in positionsEnnemis)
        {
            Enemy _enemy = new Enemy("ship1", new Vector2(0, 0), 60,1);
            _enemy.setPosition(position);
            _enemies.Add(_enemy);
        }
        _player = new Player("ship2",new Vector2(300,150), 50);
        


    }

    public void Update(GameTime gameTime)
    {
        Vector2 offset = _camera.moveCamera(_player._speed);
        _player.shootOffset(offset);
        if (offset != Vector2.Zero)
        {
            _avantPlan.setOffset(offset);
            _arrierePlan.setOffset(offset);
            _collisionMap.setOffset(offset);
            foreach (Enemy e in _enemies)
            {
                e.setOffset(offset);
            }
        }
        if (_collisionMap.CheckCollision(_player._rightHitbox))
        {
            _player._rWall = true;
        }
        else
        {
            _player._rWall = false;
        }
        if (_collisionMap.CheckCollision(_player._leftHitbox))
        {
            _player._lWall = true;
        }
        else
        {
            _player._lWall = false;
        }
        if (_collisionMap.CheckCollision(_player._bottomHitbox))
        {
            _player.groundReaction();
        }
        else
        {
            _player._surSol = false;
        }

        foreach (Enemy e in _enemies)
        {
            if (_collisionMap.CheckCollision(e._rect))
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
        _avantPlan.Update(gameTime);
        _arrierePlan.Update(gameTime);

        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        _arrierePlan.Draw(spriteBatch);
        foreach (Enemy e in _enemies)
        {
            if (!e._dead)
            {
                e.Draw(spriteBatch);
            }
        }


        _player.Draw(spriteBatch);
        _avantPlan.Draw(spriteBatch);
        
    }

    
    public String xmlMap(string xmlPath,string name)
    {
        String map = "";
        _doc.Load(xmlPath);
        XmlNode node = _doc.SelectSingleNode("//data[../@name=\""+name+"\"]");
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

    public List<Vector2> positionEnnemis(string xmlPath)
    {
        _doc.Load(xmlPath);
        XmlNodeList objets = _doc.DocumentElement.SelectNodes("//object[@name='Enemy']");
        List<Vector2> positions = new List<Vector2>();
        foreach (XmlNode objet in objets)
        {
            //positions.Add(new Vector2(float.Parse(objet.Attributes["x"].Value), float.Parse(objet.Attributes["y"].Value)));
            positions.Add(new Vector2(float.Parse(objet.Attributes["x"].Value,CultureInfo.InvariantCulture), float.Parse(objet.Attributes["y"].Value,CultureInfo.InvariantCulture)));
        }
        return positions;
    }
}