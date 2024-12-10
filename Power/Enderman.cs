using UnityEngine;

public class Enderman : MonoBehaviour
{
    [SerializeField] private float KD;
    [SerializeField] private float _tp;
    private float time;
    private AudioSource AS;

    private void Awake()
    {
        AS = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            time += Time.deltaTime;
            if (time > KD)
            {
                Tp();
                AS.Play();
            }
        }      
    }

    private void Tp()
    {
        var NextPosition = transform.position;
        var NextRotation = transform.rotation;
        time = 0;
        switch (gameObject.GetComponent<Enemy>().side)
        {
            case "Up":
                NextPosition.x += _tp;
                NextRotation.x = 0;
                NextRotation.y = -0.7f;
                NextRotation.z = 0;
                transform.position = NextPosition;
                transform.rotation = NextRotation;
                break;
            case "Down":
                NextPosition.x -= _tp;
                NextRotation.x = 0;
                NextRotation.y = 0.7f;
                NextRotation.z = 0;
                transform.position = NextPosition;
                transform.rotation = NextRotation;
                break;
            case "Left":
                NextPosition.z -= _tp;
                NextRotation.x = 0;
                NextRotation.y = 0;
                NextRotation.z = 0;
                transform.position = NextPosition;
                transform.rotation = NextRotation;
                break;
            case "Pref":
                NextPosition.z += _tp;
                NextRotation.x = 0;
                NextRotation.y = 1;
                NextRotation.z = 0;
                transform.position = NextPosition;
                transform.rotation = NextRotation;
                break;
        }
    }
}
