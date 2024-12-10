using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Towers : MonoBehaviour
{
    public int id;
    [SerializeField] private int _damage;
    public int _lvl;
    [SerializeField] private int _lvl_see;
    public int Count;
    public int _range;
    public float _atak_speed;
    private new List<GameObject> _target = new List<GameObject>();
    private float time;
    private GameObject _cel;
    private CapsuleCollider _capsule;
    private float time_rage;
    private float _max_damage;
    public int[] price_lvl;
    public float[] lvl_speed;
    public int[] lvl_atak;
    public int[] lvl_range;
    private Animator anim;
    private AudioSource AS;

    private void Awake()
    {
        Game_Manager._army += 1;
        Hero_up.Hero.Add(gameObject);
        _capsule = GetComponent<CapsuleCollider>();
        _capsule.height = _range * 2;
        _capsule.radius = _range * 2;
        _max_damage = _atak_speed;
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();

    }


    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            if (_lvl >= 2)
            {
                _atak_speed = lvl_speed[_lvl - 2];
                _max_damage = _atak_speed;
                _damage = lvl_atak[_lvl - 2];
                _range = lvl_range[_lvl - 2];
                _capsule.height = _range * 2;
                _capsule.radius = _range * 2;

            }
            time_rage -= Time.deltaTime;
            time += Time.deltaTime;
            if (time_rage > 0)
            {
                _atak_speed = _max_damage * 0.5f;
            }
            if (time_rage < 0)
            {
                _atak_speed = _max_damage;
            }
            if (_cel != null)
            {
                atak();
            }
            if (_cel == null)
            {
                _target.Remove(_cel);
                see();
            }
            if (_cel == null && _target.Count == 0)
            {
                anim.SetBool("Atak", false);
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
            AS.Play();
            anim.SetBool("Atak", true);
        }
        transform.LookAt(_cel.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }

    public void Rage(float time)
    {
        time_rage = time;
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
