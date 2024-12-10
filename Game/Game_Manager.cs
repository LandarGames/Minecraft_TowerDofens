using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public static bool Pause = false;
    public static int Gold = 200;
    public static bool Put = false;
    public static float Time_slide;
    public static float Timeng_slide = 30;
    public static int Slide = 0;
    private string _text;
    public static int _army;
    private int _nagrad;

    [SerializeField] private Text _text_gold;
    [SerializeField] private Text _text_slide;
    [SerializeField] private Text _text_timeng;
    [SerializeField] private Text _text_army;
    [SerializeField] private Text _text_win;
    [SerializeField] private Text _text_por;

    [SerializeField] private GameObject win;
    [SerializeField] private GameObject porsh;
    [SerializeField] private GameObject josh;

    public static bool wins;

    private float minut;

    private void Awake()
    {
        Pause = false;
        Put = false;
        Gold = 200;
        Timeng_slide = 30;
        Slide = 0;
        _army = 0;
        Time_slide = 0;

    }


    private void Update()
    {
        minut = Timeng_slide - Time_slide;
        if (Progress.IsAndroid == true)
        {
            josh.SetActive(true);
        }
        else if (Progress.IsAndroid == false)
        {
            josh.SetActive(false);
        }
        _nagrad = 20 * Slide;
        _text_win.text = _nagrad.ToString();
        _text_por.text = _nagrad.ToString();
        _text_army.text = $"{_army}/{Spawn_unit._max_units}".ToString();
        _text_gold.text = Gold.ToString();
        _text_slide.text = $"Волна {Slide}".ToString();
        if (Slide <= 24)
        {
            _text = $"До {Slide + 1} волны {Mathf.Round(minut)}";
        }
        else if (Slide >= 25)
        {
            _text = "Последния волна";
        }
        _text_timeng.text = _text.ToString();
        if (Pause == false && Slide <= 24)
        {
            Time_slide += Time.deltaTime;
        }
        if (Damage_home.Hp <= 0)
        {
            if (Pause == false)
            {
                Progress.almaz += _nagrad;
            }
            Pause = true;
            porsh.SetActive(true);
        }
        if (wins == true)
        {
            if (Pause == false)
            {
                Progress.almaz += _nagrad;
            }
            Pause = true;
            win.SetActive(true);

        }
    }
}
