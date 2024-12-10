using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading_map : MonoBehaviour
{
    [SerializeField] private string _map;



    public void Loads_map()
    {
        SceneManager.LoadScene(_map);
        Game_Manager.Pause = false;
        Game_Manager.wins = false;
    }
}
