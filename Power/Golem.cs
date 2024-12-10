using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _atak_speed;
    private new List<GameObject> _target = new List<GameObject>();
    private float time;

    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            if (GetComponent<Towers>() == true)
            {
                _atak_speed = GetComponent<Towers>()._atak_speed;
            }
            time += Time.deltaTime;
            if (_target.Count >= 1)
            {
                atak();
            }
            if (gameObject.GetComponent<Towers>()._lvl == 3)
            {
                _damage = 75;
            }
            if (gameObject.GetComponent<Towers>()._lvl == 4)
            {
                _damage = 100;
            }
        }
    }
    private void atak()
    {
        if (time >= _atak_speed)
        {
            time = 0;
            for (int i = 0; i < _target.Count; i++)
            {
                if (_target[i] == null)
                {
                    _target.Remove(_target[i]);
                }
                if (_target[i] != null)
                {
                    _target[i].GetComponent<Enemy>().Low_speed(0.25f);
                    _target[i].GetComponent<Enemy>().Take_damage(_damage);
                }          
            }     
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Invizable")
        {
            _target.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Invizable")
        {
            _target.Remove(collision.gameObject);
        }
    }

}
