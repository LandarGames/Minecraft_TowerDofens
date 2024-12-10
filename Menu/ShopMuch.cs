using UnityEngine;
using UnityEngine.UI;

public class ShopMuch : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private int[] _sp;

    private void Update()
    {
        gameObject.GetComponent<Text>().text = _sp[Shop._assec[_index]].ToString();
    }
}
