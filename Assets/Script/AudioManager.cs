using System.Collections;
using UnityEngine;
using Plugins.Audio.Core;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] audioClips;
    [SerializeField] private SourceAudio audioSource;
    private string _id = null;
    public bool IsNotBell;
    public bool IsPlaying { get { return audioSource.IsPlaying; } }
    private bool _isActivePause;
    public bool IsPause { get { return _isActivePause; } }

    public void PlaySound() => audioSource.Play(_id);

    public void TheBell() => InvokeRepeating("Bell", 0.2f, 1.6f);

    public void End() =>
        audioSource.Stop();
    public void Stop() =>
       audioSource.Stop();
    public void PrepareSound(int index)
    {
        _id = index.ToString();
        Click(index);
    }
       
    public void Pause()
    {
        _isActivePause = true;
         audioSource.Stop();
    }
        
    public void Resume()
    {
        _isActivePause = false;
        audioSource.Play(_id);
    }

    public void Click(int index)
    {
        if(index == 5) audioSource.Loop = true; 
        else audioSource.Loop = false;
        
        audioSource.Play(index.ToString());
        _id = index.ToString();
        PlaySound();
    }

    private void Bell()
    {
        if (!IsNotBell) audioSource.Play("5");
    }
}
