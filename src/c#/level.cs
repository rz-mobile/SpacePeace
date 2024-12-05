using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class level
{
    private Player _player;
    private Tilemap tileMapTest;
    private CollisionMap collisionMapTest;
    
    private XmlDocument doc;
    private XmlNode root;
    private XmlNamespaceManager nsmgr;
    
    private Texture2D texture;
    public Camera _camera;
    
    private List<string[]> map;

    private List<Tile> tiles;
    public level(String path ,GraphicsDevice graphicsDevice)
    {
        _camera = new Camera(new Vector2(0.0f, 0.0f));
        
        /*map = new string[10][];
        for (int i = 0; i < 10; i++)
        {
            map[i] = new String[10];
        }*/
        map = new List<string[]>();
        tiles = new List<Tile>();
        //this.texture = texture;
        
        doc = new XmlDocument();
        /*doc.Load(path);
        root = doc.DocumentElement;
        
        
        XmlElement rootElt = (XmlElement)root;
        XmlNodeList refNL = rootElt.GetElementsByTagName("//layer/data");*/
        String currentLevel = xmlMap(path);
        //Console.WriteLine(currentLevel);
        tileMapTest = new Tilemap(currentLevel);
        collisionMapTest = new CollisionMap(currentLevel,texture,graphicsDevice);
        _player = new Player("ship2",new Vector2(300,150), 50);
        


    }

    public void Update(GameTime gameTime)
    {
        Vector2 offset = _camera.moveCamera(_player.speed);
        if (offset != Vector2.Zero)
        {
            tileMapTest.setOffset(offset);
            collisionMapTest.setOffset(offset);
        }
        if (collisionMapTest.CheckCollision(_player.rightHitbox))
        {
            //Console.WriteLine("Collision Detected");
            _player.rWall = true;
        }
        else
        {
            _player.rWall = false;
        }
        if (collisionMapTest.CheckCollision(_player.leftHitbox))
        {
            _player.lWall = true;
        }
        else
        {
            _player.lWall = false;
        }
        if (collisionMapTest.CheckCollision(_player.bottomHitbox))
        {
            //Console.WriteLine("Collision Detected");
            _player.groundReaction();
        }
        else
        {
            _player.surSol = false;
        }
        _player.Update(gameTime);
        tileMapTest.Update(gameTime);

        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        tileMapTest.Draw(spriteBatch);
        _player.Draw(spriteBatch);
        //collisionMapTest.Draw(spriteBatch);
        
    }

    
    public String xmlMap(String xmlPath)
    {
        String map = "";
        doc.Load(xmlPath);
        XmlNode node = doc.SelectSingleNode("//data");
       if (node != null)
       {
           map += node.InnerText;
           //Console.WriteLine(map);
       }
       else
       {
           Console.WriteLine("échec de la création du level on ne trouve pas 'data'.");
       }
       return map;
    }
}