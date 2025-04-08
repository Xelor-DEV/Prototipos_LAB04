using UnityEngine;

public enum ColorType { Red, Blue, Yellow}
public class ColorMechanic : MonoBehaviour
{
    public ColorType color;
    public SpriteRenderer SpriteRenderer;
    public void SetTypeRed()
    {
        color = ColorType.Red;
        SpriteRenderer.color = Color.red; 
    }
    public void SetTypeBlue()
    {
        color = ColorType.Blue;
        SpriteRenderer.color = Color.blue;
    }
    public void SetTypeYellow()
    {
        color = ColorType.Yellow;
        SpriteRenderer.color = Color.yellow;
    }
}
