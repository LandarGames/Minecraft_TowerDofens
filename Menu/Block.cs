using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprite;
    public static int id;
    private Image im;

    private void Awake()
    {
        im = GetComponent<Image>();
    }

    public void Update()
    {
        var sclae = transform.localScale;
        if (transform.localScale.x >= 1 && transform.localScale.y >= 1)
        {
            sclae.x -= 1 * Time.deltaTime;
            sclae.y -= 1 * Time.deltaTime;
            transform.localScale = sclae;
        }
        im.overrideSprite = _sprite[id];
    }
}
