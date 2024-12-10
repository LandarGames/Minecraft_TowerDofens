using UnityEngine;

public class Delete_unit : MonoBehaviour
{
    [SerializeField] private GameObject _close;
    [SerializeField] private GameObject _free;
    private bool _vibor = true;
    public static GameObject Hero;
    [SerializeField] private GameObject _helper;
    private bool _start = false;

    private void Update()
    {
        if (Game.del == true)
        {
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
            if (Input.GetMouseButtonDown(0))
            {
                _vibor = true;
                Hero = null;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition + _helper.transform.position);
                transform.position = new Vector3(diference.x, transform.position.y, diference.z);
                _start = true;
            }
            if (Input.GetMouseButtonUp(0) && _start == true && _vibor == false)
            {
                Game_Manager.Gold += Hero.GetComponent<Towers>().Count / 2;
                Hero_up.Hero.Remove(Hero);
                Destroy(Hero);           
                Game.del = false;
                _start = false;
                Game_Manager._army -= 1;
            }
            else if (Input.GetMouseButtonUp(0) && _start == true && _vibor == true)
            {
                Game.del = false;
                _start = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Alietn")
        {
            _vibor = false;
            Hero = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Alietn")
        {
            _vibor = true;
            Hero = null;
        }
    }
}
