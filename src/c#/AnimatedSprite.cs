using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpacePeace;
[XmlInclude(typeof(GameObject))]
[XmlRoot("AnimatedSprite", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/AnimatedSpriteWithLists")]
[Serializable]

public class AnimatedSprite : Sprite
{
    private int _heightA , _widthA; //taille du sprite sur le png
    private int _activeFrame, _counter , _nbFrames , _nbAnimation ;
    private static int _maxAnimation , _maxFrames ;
    private Color _color = Color.White;
    
    private Rectangle Rectsrc { get => new Rectangle(_activeFrame*_widthA,_nbAnimation*_heightA,_widthA, _heightA); }

    public AnimatedSprite(string spritesheet, Vector2 position, int size,int maxAnimation, int maxFrame ) : base(spritesheet, position, size)
    {
        _activeFrame = 0;
        _maxFrames = maxFrame;
        _maxAnimation = maxAnimation-1;
        _nbAnimation = 0;
        _nbFrames = 0;
        _counter = 0;

    }
    
    public AnimatedSprite(string spritesheet, Vector2 position, int height , int width, int maxAnimation, int maxFrame ) :base(spritesheet, position, height, width)
    {
        _activeFrame = 0;
        _maxFrames = maxFrame;
        _maxAnimation = maxAnimation -1;
        _nbAnimation = 0;
        _nbFrames = 0;
        _counter = 0;
    }

    public AnimatedSprite() : base()
    {
        _heightA = 16;
        _widthA = 16;
        _maxFrames = 14;
        _maxAnimation = 3;
        _activeFrame = 0;
        _nbAnimation = 1;
        _nbFrames = 14;
        _counter = 0;

    }

    public AnimatedSprite(string spritesheet, Vector2 position, int size) : base(spritesheet, position, size){} //pour les objets sans animation
    
    public void Update(GameTime gameTime, int nbAnimation, int nbFrames)
    {
        if (nbAnimation != _nbAnimation)
        {
            _activeFrame = 0;
        }
        _nbAnimation = nbAnimation;
        _nbFrames = nbFrames;
        _counter++;
        if(_counter > (80/(nbAnimation+1)))
        {
            _counter = 0;
            _activeFrame++;
            if (_activeFrame == _nbFrames)
            {
                _activeFrame = 0;
            }
        }
    }
    
    public void Update(GameTime gameTime)
    {
            _counter++;
            if(_counter > 10)
            {
                _counter = 0;
                _activeFrame++;
                if (_activeFrame == _nbFrames)
                {
                    _activeFrame = 0;
                }
            }
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw( GetTexture(), // Texture2D,
            Rect, // Rectangle destinationRectangle,
            null, // Nullable<Rectangle> sourceRectangle,
            _color); // float layerDepth
    }
    public void Draw(SpriteBatch spriteBatch, Rectangle rec)
    {
        base.Draw(spriteBatch, Rectsrc);
    }
}