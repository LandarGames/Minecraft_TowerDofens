using UnityEngine;

public class Spawn_unit : MonoBehaviour
{
    [SerializeField] private GameObject _close;
    [SerializeField] private GameObject _free;
    private bool _vibor = false;
    public static GameObject Hero;
    [SerializeField] private Transform _point;
    [SerializeField] private GameObject _helper;
    private bool _start = false;
    [SerializeField] private int max_unit;
    public static int _max_units;
    [SerializeField] private GameObject razmer;
    [SerializeField] private GameObject dal;
    private void Awake()
    {
        _max_units = max_unit;
    }
    private void Update()
    {
        if (Game_Manager.Put == true)
        {
            razmer.SetActive(true);
            var locPostion = transform.localScale;
            locPostion = Hero.transform.localScale;
            razmer.transform.localScale = locPostion * 2;
            var LocDal = transform.localScale;
            LocDal.x = Hero.GetComponent<Towers>()._range;
            LocDal.z = Hero.GetComponent<Towers>()._range;
            dal.transform.localScale = LocDal;
            if (_vibor == false)
            {
                _close.SetActive(false);
                _free.SetActive(true);
            }
            else if (_vibor == true)
            {
                _close.SetActive(true);
                _free.SetActive(false);
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition + _helper.transform.position);
                transform.position = new Vector3(diference.x, transform.position.y, diference.z);
                _start = true;
            }
            if (Input.GetMouseButtonUp(0) && _vibor == false && _start == true)
            {
                if (Game_Manager.Gold >= Hero.GetComponent<Towers>().Count && Game_Manager._army < _max_units)
                {
                    Game_Manager.Gold -= Hero.GetComponent<Towers>().Count;
                    Instantiate(Hero, _point.position, Quaternion.identity);
                }                
                _start = false;
                Game_Manager.Put = false;            
            }
        }
        else
        {
            razmer.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.tag == "Close")
        {
            _vibor = true;
        }
    }

    private void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.tag == "Close")
        {
            _vibor = true;
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.tag == "Close")
        {
            _vibor = false;
        }
    }
}
