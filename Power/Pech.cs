using UnityEngine;

public class Pech : MonoBehaviour
{
    private float timer;
    private float bar_timer = 10;
    private int money = 20;

    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            timer += Time.deltaTime;
            if (timer >= bar_timer)
            {
                Game_Manager.Gold += money;
                timer = 0;
            }
        }
        if (gameObject.GetComponent<Towers>()._lvl == 1)
        {
            money = 15;
        }
        else if (gameObject.GetComponent<Towers>()._lvl == 2)
        {
            money = 30;
        }
        else if (gameObject.GetComponent<Towers>()._lvl == 3)
        {
            money = 45;
        }
        else if (gameObject.GetComponent<Towers>()._lvl == 4)
        {
            money = 60;
        }
    }
}
