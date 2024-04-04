
using UnityEngine;

public class Device : MonoBehaviour
{
    [SerializeField] private GameObject _conctactMobile;
    [SerializeField] private GameObject _conctactPC;

    private void Awake()
    {
        if (Application.isMobilePlatform)
        {
            _conctactMobile.SetActive(true);
        }
        else
        {
            _conctactPC.SetActive(true);
        }
    }
}
