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
    public level(String path,Texture2D texture)
    {
        this.texture = texture;
        Dictionary<Vector2, int> map = new Dictionary<Vector2, int>();
        
        doc = new XmlDocument();
        doc.Load(path);
        root = doc.DocumentElement;
        
        
        XmlElement rootElt = (XmlElement)root;
        XmlNodeList refNL = rootElt.GetElementsByTagName("//layer/data");
        String currentLevel = "0,202,202,0,0,0,229,229,0,0,\n0,202,0,202,202,202,229,229,0,0,\n0,202,0,202,202,229,229,0,0,229,\n0,202,202,0,0,229,229,0,229,0,\n0,202,202,229,229,229,229,229,0,0,\n0,202,229,229,229,202,229,0,0,0,\n0,202,229,0,0,202,229,0,0,202,\n0,202,229,0,0,202,229,0,202,0,\n0,202,202,229,229,229,229,229,0,0,\n0,202,0,202,202,229,229,229,0,0";
        
        StringReader sr = new StringReader(currentLevel);
        int y = 0;
        String line;
        while ((line = sr.ReadLine()) != null)
        {
            String[] items = line.Split(',');

            for (int x = 0; x < items.Length; x++)
            {
                if(int.TryParse(items[x], out int value))
                {
                    if (value > 0)
                    {
                        map[new Vector2(x, y)] = value;
                    }
                    
                }
            }
            y++;
        }

        tilemap = map;

        textureStore = new List<Rectangle>()
        {
            new Rectangle(0, 0, 16, 16),
            new Rectangle(0, 16, 16, 16)
        };
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var tile in tilemap)
        {
            Rectangle des = new Rectangle(
                (int)tile.Key.X * 64,
                (int)tile.Key.Y * 64,
                64,
                64
            );
            
            Rectangle src = textureStore[tile.Value];
            
            spriteBatch.Draw(texture, des, src, Color.White);

        }
    }
}