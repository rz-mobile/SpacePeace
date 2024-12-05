using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SpacePeace;

public abstract class GameObject : Sprite
{
    private Rectangle Hitbox;
    private List<GameObject> allobj;

    public GameObject(string texture, Vector2 position, int size) : base(texture, position, size)
    {
        Hitbox = new Rectangle((int)position.X, (int)position.Y, size, size);
    }

    protected Rectangle GetHitbox()
    {
        return Hitbox;
    }

    protected void SetHitbox(Rectangle hitbox)
    {
        Hitbox = hitbox;
    }

    protected void addObj(GameObject obj)
    {
        allobj.Add(obj);
    }
    public void Initialize()
    {
        allobj = new List<GameObject>();
    }

    public void Update(GameTime gameTime){
        List<GameObject> killList = new List<GameObject>();
        foreach (GameObject s in allobj)
        {
            s.Update(gameTime);
            foreach (GameObject s2 in allobj)
                if (s.Hitbox.Intersects(s2.Hitbox))
                {
                    killList.Add(s);
                } ;
           
        }
        foreach (GameObject s in killList)
        {
            allobj.Remove(s);
        }
    }

    //protected abstract void Draw(SpriteBatch spriteBatch);
}