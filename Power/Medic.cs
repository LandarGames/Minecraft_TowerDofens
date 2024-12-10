using System.Collections.Generic;
using UnityEngine;

public class Medic : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _lvl_see;
    [SerializeField] private float _atak_speed;
    private new List<GameObject> _target = new List<GameObject>();
    private float time;
    private GameObject _cel;
    private bool _power = true;

    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            if (GetComponent<Towers>() == true)
            {
                _atak_speed = GetComponent<Towers>()._atak_speed;
            }
            time += Time.deltaTime;
            if (_cel != null)
            {
                atak();
            }
            if (_cel == null)
            {
                _target.Remove(_cel);
                see();
            }
            if (Game_Manager.Time_slide >= Game_Manager.Timeng_slide - 1 && _power == true)
            {
                if (gameObject.GetComponent<Towers>()._lvl <= 2)
                {
                    Damage_home.Hp += 5;
                }
                else if (gameObject.GetComponent<Towers>()._lvl == 3)
                {
                    Damage_home.Hp += 10;
                }
                else if (gameObject.GetComponent<Towers>()._lvl == 4)
                {
                    Damage_home.Hp += 15;
                }
                _power = false;
            }
            if (Game_Manager.Time_slide <= 10 && _power == false)
            {
                _power = true;
            }
        }
       
    }
    private void atak()
    {
        if (time >= _atak_speed)
        {
            time = 0;
            _cel.GetComponent<Enemy>().Take_damage(_damage);
            if (gameObject.GetComponent<Towers>()._lvl <= 2)
            {
                _cel.GetComponent<Enemy>().Low_poizon(5);
            }
            else if (gameObject.GetComponent<Towers>()._lvl == 3)
            {
                _cel.GetComponent<Enemy>().Low_poizon(6);
            }
            else if (gameObject.GetComponent<Towers>()._lvl == 4)
            {
                _cel.GetComponent<Enemy>().Low_poizon(7);
            }
        }
        transform.LookAt(_cel.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
    private GameObject see()
    {
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        for (int i = 0; i < _target.Count; i++)
        {
            if (_target[i] == null)
            {
                _target.Remove(_target[i]);
                continue;
            }
            Vector2 diff = _target[i].transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                _cel = _target[i];
                distance = curDistance;
            }
        }
        return _cel;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" || (collision.gameObject.tag == "Invizable" && gameObject.GetComponent<Towers>()._lvl >= _lvl_see))
        {
            _target.Add(collision.gameObject);
            see();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Invizable")
        {
            if (collision.gameObject != _cel)
            {
                _target.Remove(collision.gameObject);
                see();
            }
            if (collision.gameObject == _cel)
            {
                _cel = null;
                _target.Remove(collision.gameObject);
                see();
            }
        }
    }
}
