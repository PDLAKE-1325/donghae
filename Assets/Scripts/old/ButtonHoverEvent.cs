using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverEvent : MonoBehaviour
{
    public Image img;
    public Color HoverColor;
    Color normalColor;
    void Start()
    {
        normalColor = img.color;
    }
    public void OnHover()
    {
        img.color = HoverColor;
    }
    public void OnExit()
    {
        img.color = normalColor;
    }
}
