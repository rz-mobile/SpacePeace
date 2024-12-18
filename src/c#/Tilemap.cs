using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class Tilemap
{
    private Texture2D _texture;
    
    private List<string[]> _map;

    private List<Tile> _tiles;
    private int _size;

    public Tilemap( string map,int size )
    {
        _size = size;
        _tiles = new List<Tile>();
        _map = new List<string[]>();
        string[] tmpMap = map.Split('\n');
        for (int i = 0; i < tmpMap.Length; i++)
        {
            _map.Add(tmpMap[i].Split(','));
        }

        for (int i = 0; i < _map.Count; i++)
        {
            for (int j = 0; j < _map[i].Length; j++)
            {
                if (_map[i][j] != "0" && _map[i][j] != ""  && _map[i][j] != "\t"  && _map[i][j] != "\n" && _map[i][j] != "'" && _map[i][j] != null)
                {
                    //int value = Int32.Parse(_map[i][j]);
                    //_tiles.Add(new Tile(j*_size,i*_size,value,_size));
                }
            }
        }
    }

    public void setOffset(Vector2 offset)
    {
        foreach (Tile tile in _tiles)
        {
            tile.setOffset(offset);
        }
    }
    public void Update(GameTime gameTime)
    {
        foreach (Tile tile in _tiles)
        {
            tile.Update(gameTime);
        }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Tile tile in _tiles)
        {
            tile.Draw(spriteBatch);
        }
    }
}