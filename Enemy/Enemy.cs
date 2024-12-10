using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _nagrad;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public int _hp;
    public string side = "Left";
    private float time_low;
    private float time_poizon;
    private int ticket_poizon;
    private float modific;
    private float _tick;
    public float time_power;
    private float _stan;

    [SerializeField] private bool ender_dragon;


    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            _stan -= Time.deltaTime;
            time_power -= Time.deltaTime;
            if (time_power >= 0)
            {
                modific = 5;
            }
            if (time_power < 0)
            {
                if (_hp <= 0)
                {
                    Destroy(gameObject);
                }
            }
            time_low -= Time.deltaTime;
            time_poizon -= Time.deltaTime;
            if (time_low > 0)
            {
                modific = 0.1f;
            }
            if (time_low <= 0 && time_poizon <= 0 && time_power <= 0)
            {
                modific = 1f;
            }
            if (time_poizon > 0)
            {
                _tick += Time.deltaTime;
                if (_tick >= 1)
                {
                    Take_damage(15 * ticket_poizon);
                    _tick = 0;
                    if (time_low < 0)
                    {
                        modific = 1 - 0.1f * ticket_poizon;
                    }
                }
            }
            if (time_poizon <= 0)
            {
                ticket_poizon = 0;
                if (time_low < 0 && time_power <= 0)
                {
                    modific = 1;
                }
            }
            if (ticket_poizon > 9)
            {
                ticket_poizon = 9;
            }
            if (_stan <= 0)
            {
                var NextPosition = transform.position;
                var NextRotation = transform.rotation;
                switch (side)
                {
                    case "Up":
                        NextPosition.x += _speed * Time.deltaTime * modific;
                        NextRotation.x = 0;
                        NextRotation.y = -0.7f;
                        NextRotation.z = 0;
                        transform.position = NextPosition;
                        transform.rotation = NextRotation;
                        break;
                    case "Down":
                        NextPosition.x -= _speed * Time.deltaTime * modific;
                        NextRotation.x = 0;
                        NextRotation.y = 0.7f;
                        NextRotation.z = 0;
                        transform.position = NextPosition;
                        transform.rotation = NextRotation;
                        break;
                    case "Left":
                        NextPosition.z -= _speed * Time.deltaTime * modific;
                        NextRotation.x = 0;
                        NextRotation.y = 0;
                        NextRotation.z = 0;
                        transform.position = NextPosition;
                        transform.rotation = NextRotation;
                        break;
                    case "Pref":
                        NextPosition.z += _speed * Time.deltaTime * modific;
                        NextRotation.x = 0;
                        NextRotation.y = 1;
                        NextRotation.z = 0;
                        transform.position = NextPosition;
                        transform.rotation = NextRotation;
                        break;
                }
            }
           
        }
       
    }

    public void Stan(float stan)
    {
        _stan = stan;
    }
    public void Take_damage(int hp)
    {
        if (gameObject.GetComponent<HP_bar>())
        {
            gameObject.GetComponent<HP_bar>()._razmerText = 1.5f;
            gameObject.GetComponent<HP_bar>()._timeDamage = 1f;
            gameObject.GetComponent<HP_bar>()._takeDamage += hp;
        }
        _hp -= hp;
        if (_hp <= 0 && time_power <= 0)
        {
            Game_Manager.Gold += _nagrad;
            if (ender_dragon == true)
            {
                Game_Manager.wins = true;
            }
            Destroy(gameObject);
        }
    }

    public void Low_speed(float timeng)
    {
        time_low = timeng;      
    }

    public void Low_poizon(float timeng)
    {
        time_poizon = timeng;
        ticket_poizon += 1;
        Take_damage(5 * ticket_poizon);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Left")
        {
            side = "Left";
        }
        else if (other.gameObject.tag == "Pref")
        {
            side = "Pref";
        }
        else if (other.gameObject.tag == "Down")
        {
            side = "Down";
        }
        else if (other.gameObject.tag == "Up")
        {
            side = "Up";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Home")
        {
            Damage_home.Hp -= _damage;
            Destroy(gameObject);
        }
    }
}
