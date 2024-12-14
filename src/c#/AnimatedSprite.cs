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
    private int _activeFrame, _counter , _nbFrames , _nbAnimation ;
    private Color _color = Color.White;
    
    private Rectangle Rectsrc { get => new Rectangle(_activeFrame*Width,_nbAnimation*Height,Width, Height); }

    public AnimatedSprite(string spritesheet, Vector2 position, int size,int nbAnimation, int nbFrame ) : base(spritesheet, position, size)
    {
        _activeFrame = 0;
        _nbFrames = nbFrame;
        _nbAnimation = nbAnimation;
        _counter = 0;

    }
    
    public AnimatedSprite(string spritesheet, Vector2 position, int height , int width, int nbAnimation, int nbFrame ) :base(spritesheet, position, height, width)
    {
        _activeFrame = 0;
        _nbFrames = nbFrame;
        _nbAnimation = nbAnimation;
        _counter = 0;
    }

    public AnimatedSprite() : base()
    {
        _activeFrame = 0;
        _nbAnimation = 3;
        _nbFrames = 7;
        _counter = 0;

    }

    public AnimatedSprite(string spritesheet, Vector2 position, int size) : base(spritesheet, position, size){} //pour les objets sans animation
    
    public void Update(GameTime gameTime)
    {
        if(Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.Left))
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