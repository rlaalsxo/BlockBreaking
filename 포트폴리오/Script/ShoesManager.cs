using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesManager : MonoBehaviour
{
    public Shoes shoes;
    [SerializeField]
    GameObject[] JSkills;
    private void Awake()
    {
        shoes = new Shoes();
        shoes.Index = ItemManager.instance.shoe;
        shoes.Power = 10f + shoes.Index;
        shoes.Skill = JSkills[shoes.Index];
    }
}
