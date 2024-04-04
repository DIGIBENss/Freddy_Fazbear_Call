using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;
using YG;

public class SelectVideo : MonoBehaviour
{
    [SerializeField] private VideoPlayer _player;
    [SerializeField] private GameObject _videoplayerobject, _menu, _currntCanvas, _videoButton, _audioButton;
    [SerializeField] private AudioManager _callbell;
    private string[] _videoFileName =  new string[] { "1.mp4", "2.mp4", "3.mp4", "4.mp4", "5.mp4" };
    private int _index = 0;

    [SerializeField] YandexGame _sdk;
    [SerializeField] private AdvertisementManager _advertisementmanager;

    public void SetVideoIndex(int index) => _index = index;

    public void Play()  => StartCoroutine(SelectC());

    private void Start()
    {
      Application.runInBackground = false;
    }
    private IEnumerator SelectC()
    {
        _videoplayerobject.gameObject.SetActive(true);
        if (_index > _videoFileName.Length) yield break;
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, _videoFileName[_index]);
        _callbell.Stop();
        PrepareVideo(videoPath);
    }

    public void PrepareVideo(string videoPath)
    {
        _player.url = videoPath;
        _player.Prepare();
        _player.Play();
        _player.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer player)
    {
        _index++;
        Deceline();
        _player.loopPointReached -= OnVideoEnd;
    }

    public void Deceline()
    {
        _player.Stop();
        _videoplayerobject.SetActive(false);
        _player.Stop();
        _menu.SetActive(true);
        _audioButton.SetActive(true);
        _videoButton.SetActive(true);
        _currntCanvas.SetActive(false);
    }
    public void PauseVideo()
    {
        if (_player.isPlaying && !_player.isPaused) _player.Pause();
    }

    public void ResumeVideo()
    {
        if (!_player.isPlaying && _player.isPaused)  _player.Play(); 
    }
}
