using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI  label;
    public int value;

    [SerializeField] Color unSetColor = Color.grey;
    [SerializeField] Color setColor = Color.black;
    [SerializeField] Color bcColor;
    
    public bool isSet = false;
    public bool canClick = true;
    public Image halo;
    [SerializeField] Image background;
    
    public static event Action tileClicked;

    void Awake()
    {
        label.color = unSetColor;
        ChangeValue(420);
        halo.enabled = canClick;
    }

    public void ChangeValue(int v)
    {
        if(!isSet)
        {
            value = v;
            label.text = "" + value;
        }
    }

    public void Set()
    {
        isSet = true;
        label.color = setColor;
        background.color = bcColor;
        canClick = false;
        halo.enabled = canClick;
        

    }
    public void Clickable()
    {
        canClick = true;
        halo.enabled = canClick;
    }
    
    public void NotClickable()
    {
        canClick = false;
        halo.enabled = canClick;
    }

    public void ClickTrigger()
    {
        if(canClick)
        {
           Set();
           FindObjectOfType<AudioManager>().Play("Tile");
           tileClicked?.Invoke();
        }
    }
}
