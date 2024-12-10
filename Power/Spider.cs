using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private int _hp;
    private bool _power = true;
    private AudioSource AS;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (gameObject.GetComponent<Enemy>()._hp <= _hp)
        {
            Spiders();
        }
    }

    private void Spiders()
    {
        var Position = transform.position;
        if (transform.position.y <= 30 && _power == true)
        {
            Position.y += 50 * Time.deltaTime;
            transform.position = Position;
        }
        if (transform.position.y > 30)
        {
            AS.Play();
            _power = false;
        }
    }
}
