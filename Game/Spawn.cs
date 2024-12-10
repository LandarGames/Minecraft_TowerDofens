using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform _point_spawn;
    [SerializeField] private GameObject[] _spawn;
    [SerializeField] private bool _turbo;
    private int _nagrad = 250;
    private bool _pay = true;

    private void LateUpdate()
    {
        if (Game_Manager.Time_slide >= Game_Manager.Timeng_slide)
        {
            Instantiate(_spawn[Game_Manager.Slide], _point_spawn.position, _point_spawn.transform.rotation);
            Game_Manager.Timeng_slide += 10;
            Game_Manager.Time_slide = 0;
            Game_Manager.Slide += 1;
            _pay = true;
        }
        if (Game_Manager.Time_slide >= Game_Manager.Timeng_slide - 10 && _pay == true)
        {
            Game_Manager.Gold += _nagrad;
            if (_turbo == false)
            {
                if (Game_Manager.Slide <= 10)
                {
                    _nagrad += 50;
                }
                else if (Game_Manager.Slide > 10 && Game_Manager.Slide <= 20)
                {
                    _nagrad += 25;
                }
                else if (Game_Manager.Slide > 20 && Game_Manager.Slide <= 25)
                {
                    _nagrad += 10;
                }
            }
            else
            {
                _nagrad += 250;
            }
            _pay = false;
        }
    }
}
