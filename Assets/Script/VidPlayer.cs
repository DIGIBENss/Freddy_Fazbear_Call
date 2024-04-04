using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    [SerializeField] private string _videoFileName;
    void Start()
    {
        PlayVideo();
    }
    public void PlayVideo()
    {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        if(videoPlayer != null)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
        }
    }
}
