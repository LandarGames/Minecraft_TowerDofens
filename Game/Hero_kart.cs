using UnityEngine;
using UnityEngine.UI;

public class Hero_kart : MonoBehaviour
{
    [SerializeField] private int number;
    [SerializeField] private GameObject[] hero;
    [SerializeField] private Sprite [] sprite;
    [SerializeField] private int vibor;
    [SerializeField] private Text price;
    [SerializeField] private bool up;
    private Image im;

    private void Awake()
    {
        im = GetComponent<Image>();
        im.overrideSprite = sprite[Progress.koloda[number] - 1];
        hero[Progress.koloda[number] - 1].GetComponent<Towers>()._lvl = 1;
        if (up == false)
        {
            price.text = hero[Progress.koloda[number] - 1].GetComponent<Towers>().Count.ToString();
        }
        else if (up == true)
        {
            price.text = hero[Progress.koloda[number] - 1].GetComponent<Towers>().price_lvl[hero[Progress.koloda[number] - 1].GetComponent<Towers>()._lvl - 1].ToString();
        }
    }
    public void Put()
    {
        if (Game_Manager.Put == false)
        {
            Spawn_unit.Hero = hero[Progress.koloda[number] - 1];
            Game_Manager.Put = true;
        }
        else if (Game_Manager.Put == true)
        {
            Game_Manager.Put = false;
        }
    }


    public void Lvl()
    {
        if (Game_Manager.Gold >= hero[Progress.koloda[number] - 1].GetComponent<Towers>().price_lvl[hero[Progress.koloda[number] - 1].GetComponent<Towers>()._lvl - 1] && hero[Progress.koloda[number] - 1].GetComponent<Towers>()._lvl <= 4)
        {
            Game_Manager.Gold -= hero[Progress.koloda[number] - 1].GetComponent<Towers>().price_lvl[hero[Progress.koloda[number] - 1].GetComponent<Towers>()._lvl - 1];
            hero[Progress.koloda[number] - 1].GetComponent<Towers>()._lvl += 1;
            foreach (GameObject heros in Hero_up.Hero)
            {
                if (hero[Progress.koloda[number] - 1].GetComponent<Towers>().id == heros.GetComponent<Towers>().id)
                {
                    heros.GetComponent<Towers>()._lvl += 1;
                }
            }
            if (hero[Progress.koloda[number] - 1].GetComponent<Towers>()._lvl <= 3)
            {
                price.text = hero[Progress.koloda[number] - 1].GetComponent<Towers>().price_lvl[hero[Progress.koloda[number] - 1].GetComponent<Towers>()._lvl - 1].ToString();
            }            
            else if (hero[Progress.koloda[number] - 1].GetComponent<Towers>()._lvl == 4)
            {
                price.text = 0.ToString();
            }

        }
    }
}
