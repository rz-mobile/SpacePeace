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
    
    //Constructeur
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
        _collisionMap = new CollisionMap(currentLevelCollisions,graphicsDevice,_levelSize);
       
        _enemies = new List<Enemy>();
        List<Vector2> positionsEnnemis = positionEnnemis();
        foreach (Vector2 position in positionsEnnemis)
        {
            XmlManager<Enemy> enxml = new XmlManager<Enemy>();
            Enemy enemy = enxml.Load("../../../src/xml/Enemy.xml");
            enemy.setPosition(new Vector2(position.X*levelWidthCoef(),position.Y));
            enemy.setGravity(getGravity());
            Console.WriteLine(enemy.getPosition());
            _enemies.Add(enemy);
        }
        XmlManager<Player> plxml = new XmlManager<Player>();
        _player = plxml.Load("../../../src/xml/Player.xml");
        _player.setGravity(getGravity());
        Utils._player = _player;
        _end = new EndOfLevel();
        _end.setPosition(new Vector2(positionFinDeNiveau().X*levelWidthCoef(),positionFinDeNiveau().Y));
        
        
    }
    
    
    //Fontion Update prend un GameTime en entrée et ne renvoie rien.
    //Cette fonction permet de mettre à jour le Level.
    public void Update(GameTime gameTime)
    {
        Vector2 offset = _camera.MoveCamera(_player._move);
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

            if (!e._dead && (Math.Abs(e._position.X - _player._position.X)<=400))
            {
                e.Update(gameTime);
                foreach (Shoot s in _player.tirList)
                { 
                    if (e.checkleftCollision(s._rightHitbox))
                    {
                       
                        e.die();
                        s.touche();
                        Utils.addScore(1);
                        
                        
                    }
                }
                if (e.checkTopCollision(_player._bottomHitbox))
                {
                    e.die();
                    _player._move.Y = -_player._jumpForce;
                    Utils.addScore(1);
                }else if (e.checkCollision(_player.Rect))
                {
                    _player.damage(e._degats);
                }
            }
        }

        if (_player.checkCollision(_end.Rect))
        {
            Utils.addScore(20);
            _complete = true;
        }
        
        _player.Update(gameTime);
        _avantPlan.Update(gameTime);
        _arrierePlan.Update(gameTime);
        _end.Update(gameTime, _complete);
           

        
    }
    
    //méthode Draw qui prend un SpriteBatch en entrée et qui ne renvoie rien.
    //Cette méthode permet de dessiner le level.
    public void Draw(SpriteBatch spriteBatch)
    {
        _arrierePlan.Draw(spriteBatch);
        _end.Draw(spriteBatch);
        foreach (Enemy e in _enemies)
        {
            if (!e._dead&& (Math.Abs(e._position.X - _player._position.X)<=400))
            {
                e.Draw(spriteBatch);
            }
        }


        _player.Draw(spriteBatch);
        _avantPlan.Draw(spriteBatch);
        
    }

    
    //méthode xmlMap qui prend un String en entrée et qui renvoie String.
    //Cette méthode permet de récupérer le niveau dans le fichier xml.
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
    
    
    //méthode xmlMap qui prend rien en entrée et qui renvoie une liste de Vector2.
    //Cette méthode permet de récupérer le positionnement des Ennemis dans le fichier xml.
    public List<Vector2> positionEnnemis()
    {
        _doc.Load(_path);
        XmlNodeList objets = _doc.DocumentElement.SelectNodes("//object[@name='Enemy']");
        List<Vector2> positions = new List<Vector2>();
        foreach (XmlNode objet in objets)
        {
            positions.Add(new Vector2(float.Parse(objet.Attributes["x"].Value,CultureInfo.InvariantCulture), float.Parse(objet.Attributes["y"].Value,CultureInfo.InvariantCulture)));
        }
        return positions;
    }
    
    //méthode xmlMap qui ne prend rien en entrée et qui renvoie une liste de Vector2.
    //Cette méthode permet de récupérer la fin du niveau dans le fichier xml.
    public Vector2 positionFinDeNiveau()
    {
        _doc.Load(_path);
        XmlNode objet = _doc.DocumentElement.SelectSingleNode("//object[@name='EndLevel']");
        Vector2 value = new Vector2(float.Parse(objet.Attributes["x"].Value,CultureInfo.InvariantCulture), float.Parse(objet.Attributes["y"].Value,CultureInfo.InvariantCulture));
        return value;
    }

    //Fontion getGravity prend un float en entrée et renvoi rien 
    //Cette fonction permet de recuperer la valeur de gravite du niveau
    public float getGravity()
    {
        _doc.Load(_path);
        XmlNode g = _doc.DocumentElement.SelectSingleNode("//property[@name='Gravity']");
        return float.Parse(g.Attributes["value"].Value,CultureInfo.InvariantCulture);
    }

    
    //Fontion levelWidthCoef prend un float en entrée et ne renvoie rien 
    //Cette fonction permet d'avoir la longueur du level récuperee dans le xml.
    public float levelWidthCoef()
    {
        _doc.Load(_path);
        XmlNode w = _doc.DocumentElement.SelectSingleNode("//map");
        return (((float.Parse(w.Attributes["width"].Value)*_levelSize)/Utils.screenWidth)/4);
    }
    
    //Fontion levelHeightCoef prend un float en entrée et ne renvoie rien 
    //Cette fonction permet d'avoir la hauteur du level récuperee dans le xml.
    public float levelHeightCoef()
    {
        _doc.Load(_path);
        XmlNode h = _doc.DocumentElement.SelectSingleNode("//map");
        return ((float.Parse(h.Attributes["height"].Value)*_levelSize)/Utils.screenHeight);
    }
}