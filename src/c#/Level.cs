using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;

public class Level
{
    public Player _player { get; private set; }
    private Tilemap _avantPlan;
    private Tilemap _arrierePlan;
    private CollisionMap _collisionMap;
    private List<Enemy> _enemies;
    private int _levelSize;
    private EndOfLevel _end;
    private string _path;
    public bool _complete { get;private set; }
    
    private XmlDocument _doc;
    private XmlNode _root;
    private XmlNamespaceManager _nsmgr;
    
    private Texture2D _texture;
    public Camera _camera;
    
    
    
    private List<string[]> _map;

    private List<Tile> _tiles;
    public Level(String path ,GraphicsDevice graphicsDevice)
    {
        Utils._gameOver = false;
        _path = path;
        _complete = false;
        _levelSize = 30;
        _camera = new Camera(new Vector2(0.0f, 0.0f));
        
        _map = new List<string[]>();
        _tiles = new List<Tile>();
        
        _doc = new XmlDocument();
        string currentLevelForeGround = xmlMap("AvantPlan");
        _avantPlan = new Tilemap(currentLevelForeGround,_levelSize);
        string currentLevelBackGround = xmlMap("ArrierePlan");
        _arrierePlan = new Tilemap(currentLevelBackGround,_levelSize);
        string currentLevelCollisions = xmlMap("Collision");
        _collisionMap = new CollisionMap(currentLevelCollisions,_texture,graphicsDevice,_levelSize);
        /*
        XmlManager<Player> plxml = new XmlManager<Player>();
        _player = plxml.Load(../../../src/xml/Player.xml);*/
        _enemies = new List<Enemy>();
        List<Vector2> positionsEnnemis = positionEnnemis();
        foreach (Vector2 position in positionsEnnemis)
        {
            Enemy enemy = new Enemy("player", new Vector2(0, 0), 60,1);
            enemy.setPosition(new Vector2(position.X*levelWidthCoef(),position.Y*levelHeightCoef()));
            enemy.setGravity(getGravity());
            _enemies.Add(enemy);
        }
        _player = new Player("player",new Vector2(Utils.screenWidth/2,Utils.screenWidth/8), 50);
        _player.setGravity(getGravity());
        _end = new EndOfLevel();
        _end.setPosition(new Vector2(positionFinDeNiveau().X*levelWidthCoef(),positionFinDeNiveau().Y*levelHeightCoef()));
        
        
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
            _end.setOffset(offset);
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
            if (_collisionMap.CheckCollision(e.Rect))
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
                }else if (e.checkCollision(_player.Rect))
                {
                    _player.damage(e._degats);
                }
            }
        }

        _player.Update(gameTime);
        _complete = _player.checkCollision(_end.Rect);
        _avantPlan.Update(gameTime);
        _arrierePlan.Update(gameTime);

        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        
        
        
        _arrierePlan.Draw(spriteBatch);
        _end.Draw(spriteBatch);
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

    
    public String xmlMap(string name)
    {
        String map = "";
        _doc.Load(_path);
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

    public List<Vector2> positionEnnemis()
    {
        _doc.Load(_path);
        XmlNodeList objets = _doc.DocumentElement.SelectNodes("//object[@name='Enemy']");
        List<Vector2> positions = new List<Vector2>();
        foreach (XmlNode objet in objets)
        {
            //positions.Add(new Vector2(float.Parse(objet.Attributes["x"].Value), float.Parse(objet.Attributes["y"].Value)));
            positions.Add(new Vector2(float.Parse(objet.Attributes["x"].Value,CultureInfo.InvariantCulture), float.Parse(objet.Attributes["y"].Value,CultureInfo.InvariantCulture)));
        }
        return positions;
    }
    
    public Vector2 positionFinDeNiveau()
    {
        _doc.Load(_path);
        XmlNode objet = _doc.DocumentElement.SelectSingleNode("//object[@name='EndLevel']");
        Vector2 value = new Vector2(float.Parse(objet.Attributes["x"].Value,CultureInfo.InvariantCulture), float.Parse(objet.Attributes["y"].Value,CultureInfo.InvariantCulture));
        return value;
    }

    public float getGravity()
    {
        _doc.Load(_path);
        XmlNode g = _doc.DocumentElement.SelectSingleNode("//property[@name='Gravity']");
        return float.Parse(g.Attributes["value"].Value,CultureInfo.InvariantCulture);
    }

    public float levelWidthCoef()
    {
        _doc.Load(_path);
        XmlNode w = _doc.DocumentElement.SelectSingleNode("//map");
        return (float.Parse(w.Attributes["width"].Value)*_levelSize)/Utils.screenWidth;
    }
    public float levelHeightCoef()
    {
        _doc.Load(_path);
        XmlNode h = _doc.DocumentElement.SelectSingleNode("//map");
        return (float.Parse(h.Attributes["height"].Value)*_levelSize)/Utils.screenHeight;
    }
}