using UnityEngine.UI;
using UnityEngine;

public class Damage_home : MonoBehaviour
{
    public static int Hp;
    private int max_hp;
    [SerializeField] private Text _text_hp;

    private void Awake()
    {
        Hp = 1000;
        max_hp = Hp;
    }

    private void LateUpdate()
    {
        if (Hp > max_hp)
        {
            Hp = max_hp;
        }
        _text_hp.text = $"{Hp}/{max_hp}".ToString();
    }
    
}
