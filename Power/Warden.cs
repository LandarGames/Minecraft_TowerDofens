using UnityEngine;

public class Warden : MonoBehaviour
{
    [SerializeField] private int _hp;
    private bool _power = true;


    private void Update()
    {
        if (gameObject.GetComponent<Enemy>()._hp <= _hp)
        {
            Pain();
            _power = false;
        }
    }

    private void Pain()
    {
        if (_power == true)
        {
            gameObject.GetComponent<Enemy>().time_power = 3;
            gameObject.GetComponent<Enemy>()._hp += _hp / 5;
        }        
    }
}
