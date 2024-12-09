using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SpacePeace;

public class CollisionMap
{
    public Vector2 _offset;
    private Texture2D _rectangleTexture;
    private List<string[]> _map;
    public bool done = false;
    

    private List<Rectangle> _rectangles;
    private GraphicsDevice _graphics;

    public CollisionMap(string _mmap,Texture2D rectangleTexture,GraphicsDevice graphicsDevice)
    {
        _graphics = graphicsDevice;
        _rectangles = new List<Rectangle>();
        _map = new List<string[]>();
        string[] tmpMap = _mmap.Split('\n');
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
                    int size = 60;
                    _rectangles.Add(new Rectangle((j*size)-(size/2),(i*size)-(size/2),size,size));
                }
            }
        }
        done = true;
    }
    public void setOffset(Vector2 offset)
    {
        for (int i = 0; i < _rectangles.Count;i++)
        {
            _rectangles[i] = new Rectangle(_rectangles[i].X  + (int)offset.X, _rectangles[i].Y + (int)offset.Y, _rectangles[i].Width, _rectangles[i].Height);
        }
    }

    public void Update(GameTime gameTime)
    {
        
    }
    

    public bool CheckCollision(Rectangle r)
    {
        bool collision = false;
        foreach (Rectangle rect in _rectangles)
        {
            collision = collision || rect.Intersects(r);
        }
        return collision;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Rectangle r in _rectangles)
        {
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            rect.SetData(new Color[] { Color.White });
            spriteBatch.Draw(rect, r, Color.White);
        }
    }
    
}