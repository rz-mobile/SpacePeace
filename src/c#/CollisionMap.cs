using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SpacePeace;

public class CollisionMap
{
    private List<string[]> _map;
    private int _size;
    

    private List<Rectangle> _rectangles;
    private GraphicsDevice _graphics;

    //Constructeur prenant une chaine de caracteres, un GrapgicsDevice et un entier
    public CollisionMap(string _mmap,GraphicsDevice graphicsDevice,int size)
    {
        _size = size;
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
                    _rectangles.Add(new Rectangle((j*_size)-(_size/2),(i*_size)-(_size/2),_size,_size));
                }
            }
        }
    }
    
    //méthode setOffset qui prend un Vector2 en entrée et qui ne renvoie rien
    //Cette méthode permet d'affecter le decalage de la camera au Collisions
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
    
    //méthode checkCollision qui prend un Rectangle en entrée et qui renvoie un booléan
    //Cette méthode permet de détecter une collision 
    public bool CheckCollision(Rectangle r)
    {
        bool collision = false;
        foreach (Rectangle rect in _rectangles)
        {
            collision = collision || rect.Intersects(r);
        }
        return collision;
    }
    //méthode Draw qui prend un SpriteBatch en entrée et qui ne renvoie rien
    //Cette méthode permet d'afficher les collisions de la map (fontion de debug)
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