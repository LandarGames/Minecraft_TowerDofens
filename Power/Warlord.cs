using System.Collections.Generic;
using UnityEngine;

public class Warlord : MonoBehaviour
{
    [SerializeField] private int _damage;
    private int _lvl;
    [SerializeField] private int _lvl_see;
    [SerializeField] private float _atak_speed;
    private new List<GameObject> _target = new List<GameObject>();
    private float time;
    [SerializeField] private float _kd;



    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            time += Time.deltaTime;
        }
    }
    private void atak()
    {
        if (gameObject.GetComponent<Towers>()._lvl == 2)
        {
            _kd = 9;
        }
        else if (gameObject.GetComponent<Towers>()._lvl == 3)
        {
            _kd = 8;
        }
        else if (gameObject.GetComponent<Towers>()._lvl == 4)
        {
            _kd = 7;
        }
        if (time >= _kd)
        {
            time = 0;
            for (int i = 0; i < _target.Count; i++)
            {
                _target[i].GetComponent<Towers>().Rage(5);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Invizable")
        {
            atak();
        }
        if (collision.gameObject.tag == "Alietn")
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
