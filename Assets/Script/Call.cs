using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Call : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject _videoButton;
    [SerializeField] private GameObject _call, _phone, _voiceButton;
    [Header("links")]
    [SerializeField] AudioManager _audioManager;
    [SerializeField] AdvertisementManager _advertisementManager;
    [SerializeField] private TextMeshProUGUI _nameField;
    [SerializeField] private Image _icon;
    [Header("Names"), SerializeField] private List<TextMeshProUGUI> _names;
    [Header("Icons"), SerializeField] private List<Image> _images;

    [SerializeField] private YandexGame _sdk;

    [SerializeField] private SelectVideo _selector;
    private int _soundindex = 0;
    public bool IsActiveFullscreen;
    public void StartTheBell()
    {
        _audioManager.TheBell();
        _audioManager.PrepareSound(1);
        _audioManager.PlaySound();
    }
    public void PauseAudio()
    {
        // Ïðîâåðÿåì, ÷òî ïëååð íå òîëüêî âîñïðîèçâîäèò âèäåî, íî è ÷òî âèäåî àêòèâíî (íå íà ïàóçå)
        if (_audioManager.IsPause && !_audioManager.IsPlaying) _audioManager.Pause();
    }

    public void ResumeAudio()
    {
        // Ïðîâåðÿåì, ÷òî ïëååð íå âîñïðîèçâîäèò âèäåî, è ÷òî âèäåî áûëî ïîñòàâëåíî íà ïàóçó
        if (!_audioManager.IsPause && _audioManager.IsPlaying) _audioManager.Resume();
    }
    public void PrepareCallAudio(int index)
    {
        if (index == 1 || index == 3 )
        {
            _sdk._RewardedShow(0);
            StartCoroutine(RewardTimer(2, index));
            return;
        }
        StartCoroutine(RewardTimer(0, index));
    }

    private IEnumerator RewardTimer(float time, int index)
    {
        yield return new WaitForSeconds(time);
        _audioManager.PrepareSound(6);
        _soundindex = index;
        StartCoroutine(CallShow());
        _phone.SetActive(false);
        _selector.SetVideoIndex(index);
        _nameField.text = _names[index].text;
        _icon.sprite = _images[index].sprite;
    }

    private IEnumerator CallShow()
    {
        yield return new WaitForSeconds(0.15f);
        _call.SetActive(true);
    }

    public void AcceptFeedback()
    {   
        _audioManager.IsNotBell = true;
        _audioManager.PrepareSound(_soundindex);
        _audioManager.PlaySound();
         //StartCoroutine(CheckTime());

        //_advertisementManager.StartCoroutine(_advertisementManager.CloseFeedback());
    }
    public IEnumerator CheckTime()
    {
        while (_audioManager.IsPlaying)
        {
            yield return null;
        }
        CloseBell();
    }

    private void CloseBell()
    {
        _videoButton.SetActive(true);
        _voiceButton.SetActive(true);
        _call.SetActive(false);
        _phone.SetActive(true);
    }

}
