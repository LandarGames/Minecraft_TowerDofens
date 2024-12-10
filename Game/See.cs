using UnityEngine;

public class See : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    private void Update()
    {
        if (Game_Manager.Put == true)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }
}
