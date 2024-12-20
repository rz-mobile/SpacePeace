using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpacePeace;

public class BackGround
{
    private Sprite _fond;
    private Sprite _elmtFond;
    private Sprite _meteorFond1;
    private Sprite _meteorFond2;
    private Sprite _meteorFond3;
    private Sprite _meteorFond4;
    private Sprite _meteorFond5;
    private Sprite _meteorFond6;
    private Sprite _meteorFond7;

    //Constructeur vide
    public BackGround()
    {
        _fond = new Sprite("fond", new Vector2(400,400), 1000, 1000);
        _elmtFond = new Sprite("Bomb_1_Explosion_005", new Vector2(600,150), 80, 80);
        _meteorFond1 = new Sprite("Meteor_01", new Vector2(300,200), 50, 70);
        _meteorFond2 = new Sprite("Meteor_02", new Vector2(150,50), 40, 60);
        _meteorFond3 = new Sprite("Meteor_03", new Vector2(400,60), 60, 70);
        _meteorFond4 = new Sprite("Meteor_04", new Vector2(230,80), 20, 30);
        _meteorFond5 = new Sprite("Meteor_04", new Vector2(680,250), 60, 70);
        _meteorFond6 = new Sprite("Meteor_03", new Vector2(80,300), 40, 55);
        _meteorFond7 = new Sprite("Meteor_02", new Vector2(700,40), 30, 50);
    }

    //methode Draw qui prend un SpriteBatch en entree et qui ne renvoie rien
    //Cette méthode permet de dessiner le BackGround
    public void Draw(SpriteBatch spriteBatch)
    {
        _fond.Draw(spriteBatch);
        _elmtFond.Draw(spriteBatch);
        _meteorFond1.Draw(spriteBatch);
        _meteorFond2.Draw(spriteBatch);
        _meteorFond3.Draw(spriteBatch);
        _meteorFond4.Draw(spriteBatch);
        _meteorFond5.Draw(spriteBatch);
        _meteorFond6.Draw(spriteBatch);
        _meteorFond7.Draw(spriteBatch);
    }
}