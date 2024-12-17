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
        
        /*using (TextReader reader = new StreamReader("../../../src/xml/Player.xml"))
        {
            var xmlC = new XmlSerializer(typeof(Player));
            _player = (Player)xmlC.Deserialize(reader);
        }
        */
        _enemies = new List<Enemy>();
        List<Vector2> positionsEnnemis = positionEnnemis();
        foreach (Vector2 position in positionsEnnemis)
        {
            Enemy enemy = new Enemy("player", new Vector2(0, 0), 60,1);
            enemy.setPosition(new Vector2(position.X*levelWidthCoef(),position.Y*levelHeightCoef()));
            enemy.setGravity(getGravity());
            _enemies.Add(enemy);
        }
        _player = new Player("ship2",new Vector2(Utils.screenWidth/2,Utils.screenWidth/8), 50);
        _player.setGravity(getGravity());
        _end = new EndOfLevel();
        _end.setPosition(new Vector2(positionFinDeNiveau().X*levelWidthCoef(),positionFinDeNiveau().Y*levelHeightCoef()));
        
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
        _complete = _player.checkCollision(_end._rect);
        _avantPlan.Update(gameTime);
        _arrierePlan.Update(gameTime);

        
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