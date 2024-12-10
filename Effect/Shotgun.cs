using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeng;
    [SerializeField] private bool dont;

    private float time;

    private void Update()
    {

        time += Time.deltaTime;
        if (time >= _timeng)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Invizable"))
        {
            collision.gameObject.GetComponent<Enemy>().Take_damage(_damage);
            if (dont == false)
            {
                Destroy(gameObject);
            }
        }
    }
}
