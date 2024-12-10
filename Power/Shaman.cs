using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shaman : MonoBehaviour
{
    [SerializeField] private GameObject _snake;
    [SerializeField] private Transform[] _transform;
    [SerializeField] private int max_col;
    private int col = 0;
    private bool _spawn = true;
    private List<GameObject> potch = new List<GameObject>();

    [SerializeField] private int _damage;
    [SerializeField] private int _lvl_see;
    [SerializeField] private float _atak_speed;
    private new List<GameObject> _target = new List<GameObject>();
    private float time;
    private GameObject _cel;
    [SerializeField] private GameObject _snakeTime;


    private void Update()
    {
        var NextRotation = transform.rotation;
        if (Game_Manager.Time_slide >= Game_Manager.Timeng_slide - 1 && col < max_col && _spawn == true)
        {
            Instantiate(_snake, _transform[col].position, Quaternion.identity);
            col += 1;
            _spawn = false;
        }

        if (Game_Manager.Time_slide < Game_Manager.Timeng_slide - 1 && col < max_col && _spawn == false)
        {
            _spawn = true;
        }
        if (gameObject.GetComponent<Towers>()._lvl == 1)
        {
            foreach (GameObject snake in potch)
            {
                snake.GetComponent<Towers>()._lvl = 1;
                _snake.GetComponent<Towers>()._lvl = 1;
            }
        }
        if (gameObject.GetComponent<Towers>()._lvl == 2)
        {
            foreach(GameObject snake in potch)
            {
                snake.GetComponent<Towers>()._lvl = 2;
                _snake.GetComponent<Towers>()._lvl = 2;
            }
        }
        else if (gameObject.GetComponent<Towers>()._lvl == 3)
        {
            foreach (GameObject snake in potch)
            {
                snake.GetComponent<Towers>()._lvl = 3;
                _snake.GetComponent<Towers>()._lvl = 3;
            }
        }
        else if (gameObject.GetComponent<Towers>()._lvl == 4)
        {
            foreach (GameObject snake in potch)
            {
                snake.GetComponent<Towers>()._lvl = 4;
                _snake.GetComponent<Towers>()._lvl = 4;
            }
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
    }

    private void atak()
    {
        if (time >= _atak_speed)
        {
            time = 0;
            _cel.GetComponent<Enemy>().Take_damage(_damage);
            Instantiate(_snakeTime, _cel.transform.position, Quaternion.identity);
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
        if (collision.gameObject.tag == "Snake")
        {
            potch.Add(collision.gameObject);
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
