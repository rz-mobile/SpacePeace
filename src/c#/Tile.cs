using System.Numerics;

namespace SpacePeace;

public class Tile
{
    public Vector2 position
    {
        get => position;
        private set => position = value;
        
    }

    public Sprite _sprite
    {
        get => _sprite;
        private set => _sprite = value;
    }

    public Tile(Sprite sprite)
    {
        _sprite = sprite;
    }
    public void Initialize() {
        
    }
}