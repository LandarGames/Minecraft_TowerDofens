using UnityEngine;

public class ShopBui : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private GameObject _shop;

    public void Soo()
    {
        _shop.GetComponent<Shop>().Block(Shop._assec[_index],_index);
    }
}
