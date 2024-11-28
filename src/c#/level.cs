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
        _player = new Player(playerTexture,new Vector2(100,100), 20);
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
        String currentLevel = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,276,276,276,276,276,276,276,276,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,276,276,276,276,276,0,0,0,0,0,0,276,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,276,0,0,0,0,0,0,0,0,0,276,276,0,0,0,0,0,0,0,0,0,204,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,276,0,0,0,0,0,0,0,0,0,0,0,0,204,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,276,0,0,0,0,0,0,0,0,0,0,0,0,0,204,0,0,0,0,\n0,0,0,0,0,0,0,0,0,276,276,0,0,0,0,0,0,0,138,138,138,138,139,0,0,204,0,0,0,0,\n0,138,139,0,0,0,0,276,276,0,0,0,0,0,0,0,0,0,138,139,0,138,138,139,0,204,0,0,0,0,\n0,138,138,139,0,0,276,276,0,0,0,0,0,0,0,0,0,138,139,0,0,0,138,138,139,204,0,0,0,0,\n0,0,0,138,139,0,276,0,0,0,0,0,0,0,0,0,138,138,139,0,0,0,0,138,204,204,0,0,0,0,\n0,0,0,0,138,276,139,0,0,0,0,0,0,0,0,0,138,139,0,0,0,0,0,0,204,138,139,0,0,0,\n0,0,0,0,0,276,138,139,0,0,0,0,0,0,0,138,139,0,0,0,0,0,0,0,204,138,139,0,0,0,\n0,0,0,0,0,276,276,138,139,0,0,0,0,0,138,138,139,0,0,0,0,0,0,204,204,0,0,0,0,0,\n0,0,0,0,0,0,276,276,276,276,276,0,0,138,138,139,276,276,276,276,276,276,276,276,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,138,138,276,276,276,276,276,0,0,0,0,0,0,204,204,276,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,204,204,204,0,276,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,204,204,0,0,0,276,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,204,204,0,0,0,0,0,276,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,204,204,204,204,0,0,0,0,0,0,0,276,0,0,0,0,0,\n0,0,0,0,0,0,0,204,204,204,204,204,204,204,0,0,0,0,0,0,0,0,0,0,276,0,0,0,0,0,\n0,204,204,204,204,204,204,204,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,276,276,0,0,0,0,\n204,204,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,276,276,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,276,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
        tileMapTest = new Tilemap(texture,currentLevel);
        collisionMapTest = new CollisionMap(currentLevel,texture,graphicsDevice);


    }

    public void Update(GameTime gameTime)
    {
        _player.Update(gameTime);
        if (collisionMapTest.CheckCollision(_player.bottomHitbox))
        {
            Console.WriteLine("Collision Detected");
            _player.groundReaction();
        }
        tileMapTest.Update(gameTime);

        
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        tileMapTest.Draw(spriteBatch);
        _player.Draw(spriteBatch);
        collisionMapTest.Draw(spriteBatch);
        
    }
}