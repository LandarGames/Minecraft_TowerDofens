using UnityEngine;

public class Next_down : MonoBehaviour
{
    [SerializeField] private GameObject next;
    [SerializeField] private GameObject step_down;

    public void Next()
    {
        next.SetActive(true);
        step_down.SetActive(false);
    }

}
