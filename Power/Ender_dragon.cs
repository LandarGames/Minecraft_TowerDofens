using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ender_dragon : MonoBehaviour
{

    [SerializeField] private float _speed;
    public string side = "Left";


    private void Update()
    {
        if (Game_Manager.Pause == false)
        {
            var NextPosition = transform.position;
            var NextRotation = transform.rotation;
            switch (side)
            {
                case "Up":
                    NextPosition.x += _speed * Time.deltaTime;
                    transform.position = NextPosition;
                    transform.rotation = NextRotation;
                    break;
                case "Down":
                    NextPosition.x -= _speed * Time.deltaTime;
                    transform.position = NextPosition;
                    transform.rotation = NextRotation;
                    break;
                case "Left":
                    NextPosition.z -= _speed * Time.deltaTime;
                    transform.position = NextPosition;
                    transform.rotation = NextRotation;
                    break;
                case "Pref":
                    NextPosition.z += _speed * Time.deltaTime;
                    transform.position = NextPosition;
                    transform.rotation = NextRotation;
                    break;
            }
        }       
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

}
