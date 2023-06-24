using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour, IPointerDownHandler
{
    public static ColorManager instance;
    Color color;
    string text;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.pointerEnter!= null)
        {
            GameObject obj = eventData.pointerEnter.gameObject;
            if(eventData.pointerEnter.tag == "Season")
            {
                color = obj.GetComponent<Image>().color;
                text = obj.name;
            }
            ItemManager.instance.WhatColor(text,color);
        }
    }
}
