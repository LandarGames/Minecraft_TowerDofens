using System.Collections.Generic;
using UnityEngine;
using YG;

public class Progress : MonoBehaviour
{
    public static new List<int> lists_unit = new List<int>();
    public static new List<int> koloda = new List<int>();
    public static new List<int> inventor_block = new List<int>();
    public static int almaz;
    public static bool IsAndroid;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == false)
        {
            LoadSaveCloud();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MySave();
        }
    }
    private void OnEnable() => YandexGame.GetDataEvent += LoadSaveCloud;

    private void OnDisable() => YandexGame.GetDataEvent -= LoadSaveCloud;
    public void MySave()
    {
        YandexGame.savesData.Almaz = almaz;
        YandexGame.savesData.koloda = koloda;
        YandexGame.savesData.inventor_block = inventor_block;
        YandexGame.savesData.lists_unit = lists_unit;
        YandexGame.savesData.IsAndroid = IsAndroid;
        YandexGame.SaveProgress();
    }

    public void LoadSaveCloud()
    {
        almaz = YandexGame.savesData.Almaz;
        koloda = YandexGame.savesData.koloda;
        inventor_block = YandexGame.savesData.inventor_block;
        lists_unit = YandexGame.savesData.lists_unit;
        IsAndroid = YandexGame.savesData.IsAndroid;
    }
}
