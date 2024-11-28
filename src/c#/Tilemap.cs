using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class Tilemap
{
    private Texture2D texture;

    //private String[][] map;
    private List<string[]> map;

    //private string map;
    //private ArrayList<ArrayList<String>> map;

    private List<Tile> tiles;

    public Tilemap(Texture2D texture, string _map)
    {
        tiles = new List<Tile>();
        map = new List<string[]>();
        string[] tmpMap = _map.Split('\n');
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
                    int size = 60;
                    tiles.Add(new Tile(j*size,i*size,map[i][j],texture,size));
                    //tiles.Add(new Tile(j,i,map[i][j],texture));
                    //Console.WriteLine(i +":" +j);
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