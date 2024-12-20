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
    private int _activeFrame, _counter , _nbFrames , _nbAnimation ; //paramètres pour la frame actuelle 
    private static int _maxAnimation , _maxFrames ; //parametres sur le png actuel
    private Color _color = Color.White; // a modif ligne 95
    
    private Rectangle Rectsrc { get => new Rectangle(_activeFrame*_widthA,_nbAnimation*_heightA,_widthA, _heightA); }
    // rectangle définissant la frame actuelle 
    
    //Constructeur prenant une chaine de caracteres, un Vector2 et 3 entiers
    public AnimatedSprite(string spritesheet, Vector2 position, int size,int maxAnimation, int maxFrame ) : base(spritesheet, position, size)
    {
        _heightA = 16;
        _widthA = 16;
        _activeFrame = 0;
        _maxFrames = maxFrame;
        _maxAnimation = maxAnimation-1;
        _nbAnimation = 0;
        _nbFrames = 0;
        _counter = 0;

    }
    
    //Constructeur prenant une chaine de caracteres, un Vector2 et 4 entiers
    public AnimatedSprite(string spritesheet, Vector2 position, int height , int width, int maxAnimation, int maxFrame ) :base(spritesheet, position, height, width)
    {
        _activeFrame = 0;
        _maxFrames = maxFrame;
        _maxAnimation = maxAnimation -1;
        _nbAnimation = 0;
        _nbFrames = 0;
        _counter = 0;
    }

    // Constructeur sans paramètres
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

    //Constructeur prenant une chaine de caracteres, un Vector2 et un entier
    public AnimatedSprite(string spritesheet, Vector2 position, int size) : base(spritesheet, position, size){} 
    //Constructeur prenant une chaine de caracteres, un Vector2 et 2 entiers
    public AnimatedSprite(string spritesheet, Vector2 position, int height, int width) : base(spritesheet, position, height, width){}
    
    //prend un GameTime en entrée, 2 entiers et ne renvoie rien, s'actualise a chaque image
    public void Update(GameTime gameTime, int nbAnimation, int nbFrames)
    {
        if (nbAnimation != _nbAnimation)
        {
            _activeFrame = 0;
        }
        _nbAnimation = nbAnimation;
        _nbFrames = nbFrames;
        _counter++;
        if(_counter > 20)
        {
            _counter = 0;
            _activeFrame++;
            if (_activeFrame == _nbFrames)
            {
                _activeFrame = 0;
            }
        }
    }
    //prend un GameTime en entrée et ne renvoie rien, s'actualise a chaque image
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
    
    //Prends un SpriteBatch et ne renvoie rien ,affiche le AnimatedSprite a chaque image
    public new void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw( GetTexture(),Rect,null,_color);
    }
    //Prends un SpriteBatch et un SpriteEffects et ne renvoie rien ,affiche le AnimatedSprite a chaque image
    public void Draw(SpriteBatch spriteBatch, SpriteEffects flip)
    {
        base.Draw(spriteBatch, Rectsrc, flip);
    }
    //Prends un SpriteBatch,un spriteEffect et une couleur et ne renvoie rien ,affiche le AnimatedSprite a chaque image
    public void Draw(SpriteBatch spriteBatch, SpriteEffects flip, Color color)
    {
        base.Draw(spriteBatch, Rectsrc, flip, color);
    }
    //Prends un SpriteBatch,un spriteEffect et une couleur et ne renvoie rien ,affiche le AnimatedSprite a chaque image (specifique a l'objet EndOfLevel)
    public new void Draw(SpriteBatch spriteBatch,float rotation, SpriteEffects effects, Color color )
    {
        base.DrawTrouNoir(spriteBatch, rotation, effects, color);
    }
}