using System.Collections.Generic;
using UnityEngine;

public class Hero_up : MonoBehaviour
{
    public static List<GameObject> Hero = new List<GameObject>();

    private void Awake()
    {
        Hero.Clear();
    }


}
