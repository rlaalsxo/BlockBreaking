using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTManager : MonoBehaviour
{
    [SerializeField]
    GameObject Home, Start, BackGround;
    private void Update()
    {
        if(Home.activeSelf && !BackGround.activeSelf)
        {
            Start.SetActive(true);
        }
        else
        {
            Start.SetActive(false);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
