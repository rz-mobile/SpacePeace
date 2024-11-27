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
    private Tilemap tileMapTest;
    private Dictionary<Vector2, int> tilemap;

    private List<Rectangle> textureStore;
    private XmlDocument doc;
    private XmlNode root;
    private XmlNamespaceManager nsmgr;
    
    private Texture2D texture;

    //private String[][] map;
    private List<string[]> map;
    //private ArrayList<ArrayList<String>> map;

    private List<Tile> tiles;
    public level(String path,Texture2D texture)
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
        doc.Load(path);
        root = doc.DocumentElement;
        
        
        XmlElement rootElt = (XmlElement)root;
        XmlNodeList refNL = rootElt.GetElementsByTagName("//layer/data");
        String currentLevel = "0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,276,276,276,276,276,276,276,276,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,276,276,276,276,276,0,0,0,0,0,0,276,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,276,0,0,0,0,0,0,0,0,0,276,276,0,0,0,0,0,0,0,0,0,204,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,276,0,0,0,0,0,0,0,0,0,0,0,0,204,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,276,0,0,0,0,0,0,0,0,0,0,0,0,0,204,0,0,0,0,\n0,0,0,0,0,0,0,0,0,276,276,0,0,0,0,0,0,0,138,138,138,138,139,0,0,204,0,0,0,0,\n0,138,139,0,0,0,0,276,276,0,0,0,0,0,0,0,0,0,138,139,0,138,138,139,0,204,0,0,0,0,\n0,138,138,139,0,0,276,276,0,0,0,0,0,0,0,0,0,138,139,0,0,0,138,138,139,204,0,0,0,0,\n0,0,0,138,139,0,276,0,0,0,0,0,0,0,0,0,138,138,139,0,0,0,0,138,204,204,0,0,0,0,\n0,0,0,0,138,276,139,0,0,0,0,0,0,0,0,0,138,139,0,0,0,0,0,0,204,138,139,0,0,0,\n0,0,0,0,0,276,138,139,0,0,0,0,0,0,0,138,139,0,0,0,0,0,0,0,204,138,139,0,0,0,\n0,0,0,0,0,276,276,138,139,0,0,0,0,0,138,138,139,0,0,0,0,0,0,204,204,0,0,0,0,0,\n0,0,0,0,0,0,276,276,276,276,276,0,0,138,138,139,276,276,276,276,276,276,276,276,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,138,138,276,276,276,276,276,0,0,0,0,0,0,204,204,276,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,204,204,204,0,276,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,204,204,0,0,0,276,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,204,204,0,0,0,0,0,276,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,204,204,204,204,0,0,0,0,0,0,0,276,0,0,0,0,0,\n0,0,0,0,0,0,0,204,204,204,204,204,204,204,0,0,0,0,0,0,0,0,0,0,276,0,0,0,0,0,\n0,204,204,204,204,204,204,204,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,276,276,0,0,0,0,\n204,204,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,276,276,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,276,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,\n0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0";
        tileMapTest = new Tilemap(texture,currentLevel);
        /*String[] tmpMap = currentLevel.Split('\n');
        for (int i = 0; i < tmpMap.Length; i++)
        {
            map.Add(tmpMap[i].Split(','));
        }

        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] != "0" && map[i][j] != "")
                {
                    int size = 30;
                    tiles.Add(new Tile(j*size,i*size,map[i][j],texture,size));
                    //tiles.Add(new Tile(j,i,map[i][j],texture));
                }
            }
        }*/
    }

    public void Update(GameTime gameTime)
    {
        tileMapTest.Update(gameTime);
        /*foreach (Tile tile in tiles)
        {
            tile.Update(gameTime);
        }*/
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        tileMapTest.Draw(spriteBatch);
        /*foreach (Tile tile in tiles)
        {
            tile.Draw(spriteBatch);
        }*/
    }
}