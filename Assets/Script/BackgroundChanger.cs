using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    [SerializeField] private Image _bg;
    [SerializeField] private List<Sprite> _sprites;
    private int index = 0;
    public void Change()
    {
        if(index + 1 < _sprites.Count)index++;
        else index = 0; 
        _bg.sprite = _sprites[index]; 
    }
}
