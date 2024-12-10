using UnityEngine.UI;
using UnityEngine;

public class Coint : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = Progress.almaz.ToString();
    }
}
