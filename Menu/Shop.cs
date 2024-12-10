using UnityEngine;
using YG;

public class Shop : MonoBehaviour
{
    private AudioSource AS;
    private int dawalka = 1;

    public static int[] _assec = { 0, 0, 0, 0 };

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            _assec[i] = Random.Range(1, 4);
        }
        AS = GetComponent<AudioSource>();
    }

    public void Rewarded(int id)
    {
        switch (id)
        {
            case 0:
                Progress.almaz += 500;
                AS.Play();
                Music_lobby.AudSors.Play();
                break;
            case 1:
                for (int i = 0; i <= Progress.inventor_block.Count; i++)
                {
                    if (i >= 26)
                    {
                        break;
                    }
                    if (Progress.inventor_block[i] == 0)
                    {
                        Progress.inventor_block[i] += dawalka;
                        dawalka += 1;
                        if (dawalka >= 5)
                        {
                            AS.Play();
                            Music_lobby.AudSors.Play();
                            break;
                        }
                    }
                }
                break;

        }
    }
    private void ExamplerOpenReward(int id)
    {
        Music_lobby.AudSors.Stop();
        YandexGame.RewVideoShow(id);
    }

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;

    }

    public void Almaz_block(int index)
    {
        if (Progress.almaz >= 750)
        {
            for (int i = 0; i <= Progress.inventor_block.Count; i++)
            {
                if (Progress.inventor_block[i] == 0)
                {
                    Progress.inventor_block[i] += 4;
                    Progress.almaz -= 750;
                    AS.Play();
                    _assec[index] = 0;
                    break;

                }
            }
        }
    }

    public void Gold_block(int index)
    {
        if (Progress.almaz >= 500)
        {
            for (int i = 0; i <= Progress.inventor_block.Count; i++)
            {
                if (Progress.inventor_block[i] == 0)
                {
                    Progress.inventor_block[i] += 3;
                    Progress.almaz -= 500;
                    AS.Play();
                    _assec[index] = 0;
                    break;

                }
            }
        }
    }

    public void Iron_block(int index)
    {
        if (Progress.almaz >= 250)
        {
            for (int i = 0; i <= Progress.inventor_block.Count; i++)
            {
                if (Progress.inventor_block[i] == 0)
                {
                    Progress.inventor_block[i] += 2;
                    Progress.almaz -= 250;
                    AS.Play();
                    _assec[index] = 0;
                    break;

                }
            }
        }
    }

    public void Block(int number, int index)
    {
        if (number == 4)
        {
            Almaz_block(index);
        }
        if (number == 3)
        {
            Gold_block(index);
        }
        if (number == 2)
        {
            Iron_block(index);
        }
        if (number == 1)
        {
            Ugol_block(index);
        }
    }

    public void Ugol_block(int index)
    {
        if (Progress.almaz >= 100)
        {
            for (int i = 0; i <= Progress.inventor_block.Count; i++)
            {
                if (Progress.inventor_block[i] == 0)
                {
                    Progress.inventor_block[i] += 1;
                    Progress.almaz -= 100;
                    AS.Play();
                    _assec[index] = 0;
                    break;

                }
            }
        }
    }
    public void Pack()
    {
        dawalka = 1;
        ExamplerOpenReward(1);
    }

    public void Almaz()
    {
        ExamplerOpenReward(0);
    }

    public void Refresh()
    {
        if (Progress.almaz >= 500)
        {
            Progress.almaz -= 500;
            for (int i = 0; i < 4; i++)
            {
                _assec[i] = Random.Range(1, 5);
            }
        }
    }
}
