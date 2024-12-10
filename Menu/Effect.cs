using UnityEngine;
using UnityEngine.UI;

public class Effect : MonoBehaviour
{
    private Image im;


    private void Awake()
    {
        im = GetComponent<Image>();
        im.color = new Color(255, 255, 255,0);
    }

    private void Update()
    {
        im.color -= new Color(0, 0, 0, 2 * Time.deltaTime);
    }

    public void Nes()
    {
        im.color = new Color(255, 255, 255, 255);
    }
}
