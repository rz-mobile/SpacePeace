using System;
using System.Xml;
using System.Xml.Serialization;
[Serializable]

namespace SpacePeace;

public class level
{
    private Tile[] _tileMap;
    public string tiles;

    public level(Tile[] tileMap)
    {
        _tileMap = tileMap;
    }
    
    public void Initialize() {
        _tileMap = new Tile[];
        
    }
    
}