using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] private GameObject spawn;
    [SerializeField] private int hp;
    
    void Update()
    {
        if (gameObject.GetComponent<Enemy>()._hp <= hp)
        {
            Instantiate(spawn, gameObject.transform.position, transform.rotation);
            Instantiate(spawn, gameObject.transform.position, transform.rotation);
            Destroy(gameObject);
        }    
    }
}
