using UnityEngine;

public class ShopCommon : MonoBehaviour
{
    [SerializeField] private GameObject[] _shop;
    [SerializeField] private Transform[] _tran;

    private void Awake()
    {
        Refrash();
    }
    public void Refrash()
    {
        for (int i = 0; i < _tran.Length; i++)
        {
            int random = Random.Range(0, 3);
            GameObject go = Instantiate(_shop[random], _tran[i].transform.position, Quaternion.identity);
            go.transform.SetParent(transform, false);
        }
    }
}
