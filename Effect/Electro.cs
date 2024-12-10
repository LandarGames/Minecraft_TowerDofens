using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography;

public class Electro : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private int _col;
    [SerializeField] private int _damage;
    [SerializeField] private float _stan;

    private float zader;
    private int skok;

    private void Update()
    {
        if (skok >= _col || zader >= 0.2f)
        {
            Destroy(gameObject);
        }
        ElectroAtak();
    }
    private void ElectroAtak()
    {
        foreach (Rigidbody enemy in GetExplodebalObject())
        {
            zader += Time.deltaTime;
            if (zader >= 0.1)
            {
                transform.position = enemy.transform.position;
                enemy.gameObject.GetComponent<Enemy>().Stan(_stan);
                enemy.gameObject.GetComponent<Enemy>().Take_damage(_damage);
                zader = 0;
                skok += 1;
            }
        }     
    }
    private List<Rigidbody> GetExplodebalObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> barens = new();

        foreach (Collider hit in hits)
        {
            if (hit != null && hit.GetComponent<Enemy>())
            {
                barens.Add(hit.attachedRigidbody);
            }
        }

        return barens;
    }
}
