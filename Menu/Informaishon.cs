using UnityEngine;

public class Informaishon : MonoBehaviour
{
    private bool info = false;
    [SerializeField] private GameObject tablo;

    public void Info()
    {
        if (info == true)
        {
            info = false;
            tablo.SetActive(false);
        }
        else if (info == false)
        {
            info = true;
            tablo.SetActive(true);
        }
    }
}
