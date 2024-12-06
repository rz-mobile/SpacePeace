using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public static class Utils
{
    public static ContentManager _content;
    public static GraphicsDeviceManager _graphics;
    public static Game1 _currentGame;
    public static bool _paused;
    public const int LEVEL_NUMBER = 3;
}