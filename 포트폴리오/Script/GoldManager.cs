using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    [SerializeField]
    Text Gold;
    void Start()
    {
        Gold.text = ItemManager.instance.gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Gold.text = ItemManager.instance.gold.ToString();
    }
}
