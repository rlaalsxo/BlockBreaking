using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WShopManager : MonoBehaviour
{
    [SerializeField]
    List<ShopManager> Use;
    void Start()
    {
        if (ItemManager.instance.items.Count > 0)
        {
            for(int i = 0; i< ItemManager.instance.items.Count; i++)
            {
                Use[ItemManager.instance.items[i] - 1].buy = true;
            }
        }
        if (ItemManager.instance.items.Count > 0)
        {
            for (int i = 0; i < ItemManager.instance.items.Count; i++)
            {
                if (Use[ItemManager.instance.items[i] - 1].buy)
                {
                    Use[ItemManager.instance.items[i] - 1].Gold.text = "0";
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WhatUse()
    {
        foreach(ShopManager one in Use)
        {
            if (one.use)
            {
                one.use = false;
            }
        }
    }
    public void Used()
    {
        foreach (ShopManager one in Use)
        {
            if (one.use)
            {
                one.gameObject.GetComponent<Image>().color = Color.green;
            }
            else
            {
                one.gameObject.GetComponent<Image>().color = Color.white;
            }
        }
    }
}
