using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private float cor;
    [SerializeField] private float cor_tp;

    void Update()
    {
        var nextPosition = transform.position;
        nextPosition.x -= 5 * Time.deltaTime;
        if (transform.position.x < cor_tp)
        {
            nextPosition.x = cor;
        }
        transform.position = nextPosition;
    }
}
