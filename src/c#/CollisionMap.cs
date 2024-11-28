using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SpacePeace;

public class CollisionMap
{
    private Texture2D _rectangleTexture;
    private List<string[]> map;
    

    private ArrayList rectangles;
    private GraphicsDevice _graphics;

    public CollisionMap(string _map,Texture2D rectangleTexture,GraphicsDevice graphicsDevice)
    {
        _graphics = graphicsDevice;
        rectangles = new ArrayList();
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
                    int size = 30;
                    rectangles.Add(new Rectangle(j*size,i*size,size,size));
                }
            }
        }
    }

    private void DrawRectHollow(SpriteBatch spriteBatch, Rectangle rect, int thickness, GraphicsDevice graphicsDevice)
    {
        spriteBatch.Draw(
            new Texture2D(graphicsDevice, 1, 1),
            new Rectangle(
                rect.X,
                rect.Y,
                rect.Width,
                thickness
            ),
            Color.White
        );
        spriteBatch.Draw(
            new Texture2D(graphicsDevice, 1, 1),
            new Rectangle(
                rect.X,
                rect.Bottom - thickness,
                rect.Width,
                thickness
            ),
            Color.White
        );
        spriteBatch.Draw(
            new Texture2D(graphicsDevice, 1, 1),
            new Rectangle(
                rect.X,
                rect.Y,
                thickness,
                rect.Height
            ),
            Color.White
        );
        spriteBatch.Draw(
            new Texture2D(graphicsDevice, 1, 1),
            new Rectangle(
                rect.Right - thickness,
                rect.Y,
                thickness,
                rect.Height
            ),
            Color.White
        );
    }

    public bool CheckCollision(Rectangle r)
    {
        int i = 0;
        while (i != rectangles.Count && !(((Rectangle)rectangles[i]).Intersects(r)))
        {
            i++;
        }
        return i != rectangles.Count;
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Rectangle r in rectangles)
        {
            DrawRectHollow(spriteBatch, r, 15,_graphics);
        }
    }
    
}