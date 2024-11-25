using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class level
{
    private Dictionary<Vector2, int> tilemap;

    private List<Rectangle> textureStore;
    private XmlDocument doc;
    private XmlNode root;
    private XmlNamespaceManager nsmgr;
    
    private Texture2D texture;

    private String[][] map;

    private List<Tile> tiles;
    public level(String path,Texture2D texture)
    {
        map = new string[10][];
        for (int i = 0; i < 10; i++)
        {
            map[i] = new String[10];
        }
        tiles = new List<Tile>();
        this.texture = texture;
        
        doc = new XmlDocument();
        doc.Load(path);
        root = doc.DocumentElement;
        
        
        XmlElement rootElt = (XmlElement)root;
        XmlNodeList refNL = rootElt.GetElementsByTagName("//layer/data");
        String currentLevel = "0,202,202,0,0,0,229,229,0,0,\n0,202,0,202,202,202,229,229,0,0,\n0,202,0,202,202,229,229,0,0,229,\n0,202,202,0,0,229,229,0,229,0,\n0,202,202,229,229,229,229,229,0,0,\n0,202,229,229,229,202,229,0,0,0,\n0,202,229,0,0,202,229,0,0,202,\n0,202,229,0,0,202,229,0,202,0,\n0,202,202,229,229,229,229,229,0,0,\n0,202,0,202,202,229,229,229,0,0";
        String[] tmpMap = currentLevel.Split('\n');
        for (int i = 0; i < tmpMap.Length; i++)
        {
            map[i] = tmpMap[i].Split(',');
        }

        for (int i = 0; i < map.Length; i++)
        {
            for (int j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] != "0" && map[i][j] != "")
                {
                    tiles.Add(new Tile(i*16,j*16,map[i][j],texture));
                }
            }
        }
    }

    public void Update(GameTime gameTime)
    {
        foreach (Tile tile in tiles)
        {
            tile.Update(gameTime);
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Tile tile in tiles)
        {
            tile.Draw(spriteBatch);
        }
    }
}