using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _range;
    private float time;
    private CapsuleCollider _capsule;

    private void Awake()
    {
        _capsule = GetComponent<CapsuleCollider>();
        _capsule.height = _range;
        _capsule.radius = _range;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Invizable") && time <= 0.25f)
        {
            collision.gameObject.GetComponent<Enemy>().Take_damage(_damage);
        }
    }
}
