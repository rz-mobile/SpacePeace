using System;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace SpacePeace;

[Serializable]
[XmlRoot("Item", Namespace = "http://www.univ-grenoble-alpes.fr/Item")]
public class Item:GameObject
{
    public int _points;

        //Constructeur 
    public Item(string texture, Vector2 position, int size,int points) : base(texture, position, size)
    {
        _points = points;
    }
    
}