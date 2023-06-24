using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    public Text Gold;
    Sprite weapon;
    int a;
    public int price;
    public bool use = false;
    public bool buy = false;
    private void Awake()
    {
        weapon = this.gameObject.GetComponent<Image>().sprite;
        a = int.Parse(weapon.name);
        price = a * 100;
        Gold.text= price.ToString();
    }
    public void Buy()
    {
       if(ItemManager.instance.gold >= price && !buy)
        {
            ItemManager.instance.gold -= price;
            buy = true;
            use = true;
            ItemManager.instance.weapon = a;
            ItemManager.instance.items.Add(a);
            this.gameObject.GetComponent<AudioSource>().Play();
        }
        else if (buy)
        {
            ItemManager.instance.weapon = a;
            use = true;
        }
    }
}
