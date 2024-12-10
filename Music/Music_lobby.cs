using UnityEngine;

public class Music_lobby : MonoBehaviour
{
    public static AudioSource AudSors;
    [SerializeField] private AudioClip[] music;

    private void Awake()
    {
        AudSors = GetComponent<AudioSource>();
        AudSors.clip = music[Random.Range(0, music.Length)];
        AudSors.Play();
    }

    private void PlayHeartSound()
    {
        AudSors.clip = music[Random.Range(0,music.Length)];
        AudSors.Play();
    }


}
