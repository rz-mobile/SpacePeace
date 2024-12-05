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
    private List<string[]> map;
    public bool done = false;
    

    private List<Rectangle> rectangles;
    private GraphicsDevice _graphics;

    public CollisionMap(string _map,Texture2D rectangleTexture,GraphicsDevice graphicsDevice)
    {
        _graphics = graphicsDevice;
        rectangles = new List<Rectangle>();
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
                    rectangles.Add(new Rectangle((j*size)-(size/2),(i*size)-(size/2),size,size));
                    //Console.WriteLine(i*size +":" +j*size);
                }
            }
        }
        //Console.WriteLine("done");
        done = true;
    }
    public void setOffset(Vector2 offset)
    {
        for (int i = 0; i < rectangles.Count;i++)
        {
            rectangles[i] = new Rectangle(rectangles[i].X  + (int)offset.X, rectangles[i].Y + (int)offset.Y, rectangles[i].Width, rectangles[i].Height);
        }
    }

    public void Update(GameTime gameTime)
    {
        
    }
    

    public bool CheckCollision(Rectangle r)
    {
        /*int i = 0;
        while (i != rectangles.Count && !((rectangles[i]).Intersects(r)))
        {
            i++;
        }
        return i != rectangles.Count;*/
        bool collision = false;
        foreach (Rectangle rect in rectangles)
        {
            collision = collision || rect.Intersects(r);
            //Console.WriteLine(rect.ToString() + ":" + r.ToString() + "--" + collision.ToString());
        }
        return collision;
        //return false;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Rectangle r in rectangles)
        {
            Texture2D rect = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            rect.SetData(new Color[] { Color.White });
            spriteBatch.Draw(rect, r, Color.White);
        }
    }
    
}