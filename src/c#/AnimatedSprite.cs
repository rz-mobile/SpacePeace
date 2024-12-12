using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;
[XmlInclude(typeof(GameObject))]
[XmlRoot("AnimatedSprite", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/animatedSprites")]
[Serializable]

public class AnimatedSprite
{
    private Texture2D[] _tabTexture;
    [XmlElement("list_Texture")] private List<string> _listName;
    protected Vector2 Position;
    [XmlElement("height")]public int Height;
    [XmlElement("width")]public int Width;
    private int _animationFrame, _counterFrame;
    private Color _color = Color.White;
    
    public Rectangle _rect { get => new Rectangle((int) Position.X - Width/2, (int) Position.Y - Height/2,Width, Height); }
    public AnimatedSprite(string texture, Vector2 position, int size, int nbAnimations)
    {
        _listName = new List<string>(nbAnimations);
        string s;
        for(short i = 1; i < nbAnimations+1; i++)
        {
            s = texture + "_phase" + i;
            _listName[i-1] = s;
        }
        
        _tabTexture = new Texture2D[nbAnimations];
        for (int i = 0; i < nbAnimations; i++)
        {
            _tabTexture[i] = Utils._content.Load<Texture2D>(_listName[i]);
        }
        Position = position; 
        Height = size;
        Width = size;
        _animationFrame = 0;
        _counterFrame = 0;
    }
    
    public AnimatedSprite(string texture, Vector2 position, int height , int width, int nbAnimations) 
    {
        _listName = new List<string>(nbAnimations);
        string s;
        for(short i = 1; i < nbAnimations+1; i++)
        {
            s = texture + "_phase" + i;
            _listName[i-1] = s;
        }
        
        _tabTexture = new Texture2D[nbAnimations];
        for (int i = 0; i < nbAnimations; i++)
        {
            _tabTexture[i] = Utils._content.Load<Texture2D>(_listName[i]);
        }
        Position = position; 
        Height = height;
        Width = width;
        _animationFrame = 0;
        _counterFrame = 0;
    }

    public AnimatedSprite()
    {
        _tabTexture = new Texture2D[7];
        _listName = new List<string> { "run_phase1", "run_phase2", "run_phase3", "run_phase4", "run_phase5", "run_phase6", "run_phase7" };
        for (int i = 0; i < 7; i++)
        {
            _tabTexture[i] = Utils._content.Load<Texture2D>(_listName[i]);
        }
        Position = new Vector2(300, 300);
        Height = 10;
        Width = 10;
        _animationFrame = 0;
        _counterFrame = 0;
    }

    public void setPosition(Vector2 position)
        {
            Position = position;
        }
    public void Update(GameTime gameTime)
    {
        if (_counterFrame > 29)
        {
            _counterFrame = 0;
            _animationFrame++;
            if (_animationFrame >= _tabTexture.Length)
            {
                _animationFrame = 0;
            }
        }
        _counterFrame++;
    }
    public void Draw(SpriteBatch spriteBatch) {
        spriteBatch.Draw(   _tabTexture[_animationFrame], // Texture2D,
            _rect, // Rectangle destinationRectangle,
            null, // Nullable<Rectangle> sourceRectangle,
            _color); // float layerDepth
    }

    public void Draw(SpriteBatch spriteBatch, Rectangle src)
    {
        spriteBatch.Draw(   _tabTexture[_animationFrame], // Texture2D,
            _rect, // Rectangle destinationRectangle,
            src, // Nullable<Rectangle> sourceRectangle,
            _color ); // float layerDepth
    }
}