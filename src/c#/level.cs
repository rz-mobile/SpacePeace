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
    
    private List<string[]> map;

    private List<Tile> tiles;
    public level(String path,Texture2D texture,Texture2D playerTexture,GraphicsDevice graphicsDevice)
    {
        
        /*map = new string[10][];
        for (int i = 0; i < 10; i++)
        {
            map[i] = new String[10];
        }*/
        map = new List<string[]>();
        tiles = new List<Tile>();
        this.texture = texture;
        
        doc = new XmlDocument();
        /*doc.Load(path);
        root = doc.DocumentElement;
        
        
        XmlElement rootElt = (XmlElement)root;
        XmlNodeList refNL = rootElt.GetElementsByTagName("//layer/data");*/
        String currentLevel =
            "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n178,178,178,178,178,178,0,0,0,178,178,178,178,178,178,178,178,178,178,178,178,0,178,178,178,178,178,0,0,0";
            tileMapTest = new Tilemap(texture,currentLevel);
        collisionMapTest = new CollisionMap(currentLevel,texture,graphicsDevice);
        if (collisionMapTest.done)
        {
            _player = new Player(playerTexture,new Vector2(100,100), 50);
        }
        


    }

    public void Update(GameTime gameTime)
    {
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
        collisionMapTest.Draw(spriteBatch);
        
    }
}