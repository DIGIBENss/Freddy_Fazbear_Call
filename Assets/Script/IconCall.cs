using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconCall : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite[] _iconcout = new Sprite[5];  
    public void IndexImage(int  index)
    {
        _icon.sprite = _iconcout[index];
    }
}
