using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField]
    public Block block;
    [SerializeField]
    GameObject DP;
    Rigidbody rb;
    int result = 0;
    public int currenthp;
    string thisname;
    private void Awake()
    {
        thisname = this.gameObject.name.Replace("(Clone)", string.Empty);
        block = new Block();
        int.TryParse(thisname, out result);
        block.Level = result;
        block.Damage = 1;
        block.HP = block.Level * 10;
        currenthp = block.HP;
        block.Speed = 2f;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.velocity = transform.up * 4f * -1;
    }

    // Update is called once per frame
    void Update()
    {
        Break(); 
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            Instantiate(DP);
            CharacterManager.instance.currenthp -= block.Damage;
            CanvasManager.instance.HeartCount();
        }
    }
    void Break()
    {
        if(currenthp <= 0)
        {
            CharacterManager.instance.Break(this.gameObject);
        }
    }
}
