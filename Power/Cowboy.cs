using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour
{
    [SerializeField] private int _damage;
    private int _lvl;
    [SerializeField] private int _lvl_see;
    [SerializeField] private float _atak_speed;
    private new List<GameObject> _target = new List<GameObject>();
    private float time;
    private GameObject _cel;
    private int _bullet = 6;
    [SerializeField] private float _kd;



    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            time += Time.deltaTime;
            if (GetComponent<Towers>() == true)
            {
                _atak_speed = GetComponent<Towers>()._atak_speed;
            }
            if (gameObject.GetComponent<Towers>()._lvl == 2)
            {
                _damage = 40;
            }
            if (gameObject.GetComponent<Towers>()._lvl == 3)
            {
                _damage = 50;
            }
            if (gameObject.GetComponent<Towers>()._lvl == 4)
            {
                _damage = 60;
                _kd = 2;
            }
            if (_cel != null && _bullet > 0)
            {
                atak();
            }
            if (_bullet <= 0 || (_bullet < 6 && time > _kd * 2))
            {
                if (time >= _kd)
                {
                    _bullet = 6;
                }
            }
            if (_cel == null || _cel.GetComponent<Enemy>()._hp < 0)
            {
                _target.Remove(_cel);
                see();
            }
        }
        
    }
    private void atak()
    {
        if (time >= _atak_speed)
        {
            time = 0;
            _cel.GetComponent<Enemy>().Take_damage(_damage);
            _bullet -= 1;
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
        if (collision.gameObject.tag == "Enemy" || (collision.gameObject.tag == "Invizable" && _lvl >= _lvl_see))
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
