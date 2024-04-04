using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class AdvertisementManager : MonoBehaviour
{
    [Header("FullscreenShow")]
    [SerializeField] private TextMeshProUGUI _textad;
    [SerializeField] private YandexGame _sdk;
    [SerializeField] private GameObject _fulladScreen;

    [Header("Feedback")]
    [SerializeField] private GameObject _feedback;
    [SerializeField] private GameObject _callobject;
    [SerializeField] private GameObject _phone;
    [SerializeField] private Call _call;
    [SerializeField] private SelectVideo _video;
    public bool _isActiveCall;
    
    private void Start()
    {
        StartCoroutine(BeforeAdvertising());
    }
    public void BeforeFeedback()
    {
        _feedback.SetActive(true);
        _call.StartTheBell();
    }
    public IEnumerator CloseFeedback()
    {
        yield return new WaitForSeconds(13f);
        _feedback.SetActive(false);
    }
    private IEnumerator BeforeAdvertising()
    {
        yield return new WaitForSeconds(51f);
        Time.timeScale = 0;
        _fulladScreen.SetActive(true);
        StartCoroutine(AfterAdvertising());
    }
    public void CallActive()
    {
        if(_isActiveCall)
        {
            _isActiveCall = false;
            _callobject.SetActive(true);
            _phone.SetActive(false);
        }
    }
    private IEnumerator AfterAdvertising()
    {
        for (int i = 10; i >= 0; i--)
        {
            yield return new WaitForSeconds(1f);
            _textad.text = i.ToString();
            if(i == 0)
            {
                _isActiveCall = true;
                _sdk._FullscreenShow();
                _fulladScreen.SetActive(false);
                Time.timeScale = 1;
                //CallActive();
            }
        }
    }
}
