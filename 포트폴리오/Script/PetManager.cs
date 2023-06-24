using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] pets;
    public Pet pet;
    int[] indexs = { 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4 };
    int index;
    private void Awake()
    {
        pet = new Pet();
        index = Random.Range(0, indexs.Length - 1);
        pet.Index = indexs[index];
        switch (pet.Index)
        {
            case 0:
                pet.Score = 20;
                pet.Damage = 0;
                pet.Gold = 0;
                pet.HP = 0;
                break;
            case 1:
                pet.Score = 0;
                pet.Damage = 20;
                pet.Gold = 0;
                pet.HP = 0;
                break;
            case 2:
                pet.Score = 0;
                pet.Damage = 0;
                pet.Gold = 10;
                pet.HP = 0;
                break;
            case 3:
                pet.Score = 0;
                pet.Damage = 0;
                pet.Gold = 0;
                pet.HP = 2;
                break;
            case 4:
                pet.Score = 20;
                pet.Damage = 20;
                pet.Gold = 10;
                pet.HP = 2;
                break;
        }
    }
    void Start()
    {
        GameObject myPet = Instantiate(pets[pet.Index]);
        myPet.transform.SetParent(this.gameObject.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
