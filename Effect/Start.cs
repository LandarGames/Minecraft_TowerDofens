using UnityEngine;

public class Start : MonoBehaviour
{
    private float skor = 1;
    private SpriteRenderer SR;
    private void Awake()
    {
        gameObject.SetActive(true);
        SR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Game_Manager.Slide >= 1)
        {
            gameObject.SetActive(false);
        }
        if (SR.color.a >= 0.99f)
        {
            skor = 1;
        }
        else if (SR.color.a <= 0.01f)
        {
            skor = -1;
        }
        SR.color -= new Color(0, 0, 0, skor * Time.deltaTime);
    }
}
