using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SpacePeace;

public abstract class GameObject : Sprite
{
    private Rectangle _hitbox;
    private List<GameObject> allobj;

    public GameObject(string texture, Vector2 position, int size) : base(texture, position, size)
    {
        _hitbox = new Rectangle((int)position.X, (int)position.Y, size, size);
    }

    protected Rectangle GetHitbox()
    {
        return _hitbox;
    }

    protected void SetHitbox(Rectangle hitbox)
    {
        _hitbox = hitbox;
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
                if (s._hitbox.Intersects(s2._hitbox))
                {
                    killList.Add(s);
                } ;
           
        }
        foreach (GameObject s in killList)
        {
            allobj.Remove(s);
        }
    }
    
}