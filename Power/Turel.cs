using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Turel : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _atak_speed;
    private new List<GameObject> _target = new List<GameObject>();
    private float time;
    private GameObject _cel;
    private float _hot = 0;
    private float _kd;
    [SerializeField] private float _cold;
    [SerializeField] private float _perefref;
   




    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            _kd -= Time.deltaTime;
            if (gameObject.GetComponent<Towers>()._lvl == 1)
            {
                _damage = 30;
            }
            if (gameObject.GetComponent<Towers>()._lvl == 2)
            {
                _damage = 40;
            }
            else if (gameObject.GetComponent<Towers>()._lvl == 3)
            {
                _damage = 50;
            }
            else if (gameObject.GetComponent<Towers>()._lvl == 4)
            {
                _damage = 60;
            }
            if (_kd <= 0)
            {
                if (GetComponent<Towers>() == true)
                {
                    _atak_speed = GetComponent<Towers>()._atak_speed;
                }
                time += Time.deltaTime;
                if (_cel != null && _hot <= _perefref && _kd <= 0)
                {
                    atak();
                    _hot += Time.deltaTime;
                }
                if (_cel == null || _cel.GetComponent<Enemy>()._hp < 0 && _target.Count <= 0 && _hot >= 0)
                {
                    _target.Remove(_cel);
                    if (_hot > 0)
                    {
                        _hot -= Time.deltaTime;
                    }
                    see();
                }
                if (_hot >= _perefref)
                {
                    _kd = _cold;
                    _hot = 0;
                }
            }
            Debug.Log(_hot);
        }
        
    }
    private void atak()
    {
        if (time >= _atak_speed)
        {
            time = 0;
            _cel.GetComponent<Enemy>().Take_damage(_damage);
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
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Invizable")
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
