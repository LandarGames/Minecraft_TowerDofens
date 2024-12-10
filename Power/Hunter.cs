using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    [SerializeField] private int _damage;
    private int _lvl;
    [SerializeField] private int _lvl_see;
    [SerializeField] private float _atak_speed;
    private new List<GameObject> _target = new List<GameObject>();
    private float time;
    private GameObject _cel;
    [SerializeField] private GameObject _shot;
    [SerializeField] private GameObject _shot1;
    [SerializeField] private GameObject _shot2;
    [SerializeField] private GameObject _shot3;



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
            if (gameObject.GetComponent<Towers>()._lvl == 1)
            {
                Instantiate(_shot, transform.position, transform.rotation);
            }
            else if (gameObject.GetComponent<Towers>()._lvl == 2)
            {
                Instantiate(_shot1, transform.position, transform.rotation);
            }
            else if (gameObject.GetComponent<Towers>()._lvl == 3)
            {
                Instantiate(_shot2, transform.position, transform.rotation);
            }
            else if (gameObject.GetComponent<Towers>()._lvl == 4)
            {
                Instantiate(_shot3, transform.position, transform.rotation);
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
