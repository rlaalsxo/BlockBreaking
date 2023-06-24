using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon weapon;
    [SerializeField]
    GameObject[] Weapons, ASkills;
    private void Awake()
    {
        weapon = new Weapon();
        weapon.Index = ItemManager.instance.weapon;
        weapon.Damage = 10 * weapon.Index;
        weapon.Length = 4f + (weapon.Index / 10f);
        weapon.Skill = ASkills[weapon.Index];
    }
    private void OnEnable()
    {
        
    }
    private void Start()
    {
        GameObject myWeapon = Instantiate(Weapons[weapon.Index]);
        myWeapon.transform.SetParent(this.gameObject.transform, false);
    }
}
