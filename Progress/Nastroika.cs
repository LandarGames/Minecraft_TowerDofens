using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nastroika : MonoBehaviour
{
    [SerializeField] private GameObject gm;

    public void Nastr()
    {
        gm.SetActive(true);
    }
    public void IsAndroids()
    {
        Progress.IsAndroid = true;
        gm.SetActive(false);
    }

    public void IsPK()
    {
        Progress.IsAndroid = false;
        gm.SetActive(false);
    }
}
