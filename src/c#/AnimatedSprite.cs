using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace SpacePeace;
[XmlRoot("AnimatedSprite", Namespace = "http://www.univ-grenoble-alpes.fr/l3miage/spacePeace/animatedSprites")]
[Serializable]

public class AnimatedSprite : Sprite
{
    [XmlElement("animation")] private List<string> animations;
    public AnimatedSprite(string texture, Vector2 position, int size):base(texture, position, size)
    {
        
    }

    public AnimatedSprite() : base()
    {
        
    }
}