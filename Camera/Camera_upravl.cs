using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;

public class Camera_upravl : MonoBehaviour
{
    [SerializeField] private float x_min;
    [SerializeField] private float x_max;
    [SerializeField] private float z_min;
    [SerializeField] private float z_max;

    private bool camera_up = false;
    private bool camera_down = false;
    private bool camera_left = false;
    private bool camera_right = false;




    private void Update()
    {
        var NextPosition = transform.position;
        if (Progress.IsAndroid == false)
        {
            if (Input.GetKey(KeyCode.W) && transform.position.z < z_max)
            {
                NextPosition.z += 25 * Time.deltaTime;
                transform.position = NextPosition;
            }
            if (Input.GetKey(KeyCode.S) && transform.position.z > z_min)
            {
                NextPosition.z -= 25 * Time.deltaTime;
                transform.position = NextPosition;
            }
            if (Input.GetKey(KeyCode.A) && transform.position.x > x_min)
            {
                NextPosition.x -= 25 * Time.deltaTime;
                transform.position = NextPosition;
            }
            if (Input.GetKey(KeyCode.D) && transform.position.x < x_max)
            {
                NextPosition.x += 25 * Time.deltaTime;
                transform.position = NextPosition;
            }
        }
        if (Progress.IsAndroid == true)
        {
            if (camera_up == true && transform.position.z < z_max)
            {
                NextPosition.z += 25 * Time.deltaTime;
                transform.position = NextPosition;
            }
            if (camera_down == true && transform.position.z > z_min)
            {
                NextPosition.z -= 25 * Time.deltaTime;
                transform.position = NextPosition;
            }
            if (camera_left == true && transform.position.x > x_min)
            {
                NextPosition.x -= 25 * Time.deltaTime;
                transform.position = NextPosition;
            }
            if (camera_right == true && transform.position.x < x_max)
            {
                NextPosition.x += 25 * Time.deltaTime;
                transform.position = NextPosition;
            }
        }

    }


    public void Left_close()
    {
        camera_left = false;
    }

    public void Up_close()
    {
        camera_up = false;
    }

    public void Down_close()
    {
        camera_down = false;
    }

    public void Pref_close()
    {
        camera_right = false;
    }

    public void Left()
    {
        camera_left = true;
    }

    public void Up()
    {
        camera_up = true;
    }

    public void Down()
    {
        camera_down = true;
    }

    public void Pref()
    {
        camera_right = true;
    }

}
