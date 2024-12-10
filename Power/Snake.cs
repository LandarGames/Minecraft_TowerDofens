using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    private float time = 0;
    private void Update()
    {
        Live();
    }

    private void Live()
    {
        time += Time.deltaTime;
        if (time >= _lifeTime)
        {
            Destroy(gameObject);
        }    
    }
}
