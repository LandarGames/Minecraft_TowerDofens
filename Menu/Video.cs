using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    private VideoPlayer videoplayer;
    
    private void Start()
    {
        videoplayer = GetComponent<VideoPlayer>();
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, "Video_menu.mp4");
        videoplayer.url = videoPath;
        videoplayer.Play();
    }

}
