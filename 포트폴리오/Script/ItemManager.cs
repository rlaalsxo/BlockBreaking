using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public int weapon, shoe, gold;
    public Color color;
    public string text;
    [SerializeField]
    AudioSource bgm;
    [SerializeField]
    AudioClip[] bgms;
    public List<int> items;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        weapon = 0;
        shoe = 0;
        gold = 1000;
    }
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    public void BattleLoad()
    {
        SceneManager.LoadScene("BattleScene");
        DontDestroyOnLoad(gameObject);
        bgm.clip = bgms[1];
        bgm.Play();
    }
    public void StartLoad()
    {
        SceneManager.LoadScene("StartScene");
        DontDestroyOnLoad(gameObject);
        bgm.clip = bgms[0];
        bgm.Play();
    }
    public void WhatColor(string _text, Color _color)
    {
        text = _text;
        color= _color;
        BattleLoad();
    }
}
