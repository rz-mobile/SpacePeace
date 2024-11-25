using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class GameObject
{
    protected Sprite sprite;
    protected Hitbox hitbox;
    protected Vector2 position;

    public GameObject(Texture2D sprite, Hitbox hitbox)
    {
        position = new Vector2(0, 0);
        this.sprite = new Sprite(sprite,position,1);
        this.hitbox = hitbox;
    }
    
    public void Initialize(){}
    
    public void Update(GameTime gameTime){}

    public void Draw(SpriteBatch spriteBatch)
    {
        sprite.Draw(spriteBatch);
    }
}