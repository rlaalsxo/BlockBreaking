using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    [SerializeField]
    GameObject WeaponPos, GardPos, JumpPos, ASkillPos, dmgtext, textPos;
    [SerializeField]
    WeaponManager myWeapon;
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    ShoesManager myShoes;
    [SerializeField]
    AudioSource myAudio;
    [SerializeField]
    AudioClip[] myAudioClip;
    [SerializeField]
    public PetManager MyPet;
    public GameObject ASkillEf, JSkillEf;
    public List<GameObject> blocks;
    public List<BlockManager> SkillDamage;
    public BlockManager block;
    public int hp = 3;
    public int currenthp;
    public int damage = 10;
    public int Combo, JumpCount = 0;
    public float skillcooltime = 2f;
    public float attackDis, jumpP;
    bool jump = false;
    bool isGround;
    Animator animator;
    Rigidbody myRigid;
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
        this.gameObject.SetActive(true);
        myRigid = this.gameObject.GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        jumpP = myShoes.shoes.Power;
        damage += damage * (MyPet.pet.Damage / 100);
        hp += MyPet.pet.HP;
        currenthp = hp;
        JSkillEf = myShoes.shoes.Skill;
        damage += myWeapon.weapon.Damage;
        attackDis = myWeapon.weapon.Length;
        ASkillEf = myWeapon.weapon.Skill;
    }
    void Update()
    {
        IsGround();
        skillcooltime += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        myRigid.AddForce(Vector3.down * 10f);
    }
    public void Attack()
    {
        SearchBlock();
        animator.SetBool("IsAttack", true);
        myAudio.clip = myAudioClip[0];
        myAudio.Play();
        Hit();
    }
    public void Jump()
    {
        if (!jump)
        {
            jump = true;
            isGround = false;
            animator.SetTrigger("Jump");
            animator.SetBool("Falling", true);
            myRigid.velocity = transform.up * jumpP;
            JumpCount++;
            this.gameObject.layer = 7;
            myAudio.clip = myAudioClip[1];
            myAudio.Play();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void IsGround()
    {
        if (isGround)
        {
            animator.SetBool("Falling", false);
            jump = false;
            if (!animator.GetBool("IsAttack"))
            {
                this.gameObject.layer = 3;
            }
        }
        else
        {

        }
    }
    public void AttackEnd()
    {
        animator.SetBool("IsAttack", false);
    }
    public void AttackSkill()
    {
        SkillTarget();
        GameObject ASkill = Instantiate(ASkillEf);
        ASkill.transform.SetParent(ASkillPos.transform, false);
        animator.SetTrigger("WSkill");
        myRigid.velocity = transform.up * jumpP;
        myAudio.clip = myAudioClip[2];
        myAudio.Play();
        if (SkillDamage.Count > 0)
        {
            for(int i = 0; i<SkillDamage.Count; i++)
            {
                SkillDamage[i].currenthp -= 1000;
                DamageTextCreate(textPos, damage);
            }
        }
        ClearFun();
    }
    public void JumpSkill()
    {
        SkillTarget();
        GameObject JSkill = Instantiate(JSkillEf);
        JSkill.transform.SetParent(JumpPos.transform, false);
        animator.SetTrigger("JSkill");
        myRigid.velocity = transform.up * jumpP;
        myAudio.clip = myAudioClip[3];
        myAudio.Play();
        if (SkillDamage.Count > 0)
        {
            for (int i = 0; i < SkillDamage.Count; i++)
            {
                SkillDamage[i].currenthp -= 1000;
                DamageTextCreate(textPos, damage);
            }
        }
        ClearFun();
    }
    void Hit()
    {
        if(blocks.Count > 0)
        {
            block = blocks[0].GetComponent<BlockManager>();
            if (animator.GetBool("IsAttack") && Vector3.Distance(this.gameObject.transform.position, block.gameObject.transform.position) <= attackDis)
            {
                block.currenthp -= damage;
                DamageTextCreate(textPos, damage);
                myAudio.clip = myAudioClip[4];
                myAudio.Play();
            }
            blocks.Clear();
        }
    }
    public void Gard()
    {
        if(skillcooltime >= 2f)
        {
            GardPos.SetActive(true);
            skillcooltime = 0;
        }
    }
    void SearchBlock()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Block");
        if(objs.Length > 0)
        {
            for (int i = 0; i < objs.Length; i++)
            {
                blocks.Add(objs[i]);
            }
            blocks.Sort((a, b) => Vector3.Distance(a.transform.position, BlockGameManager.instance.Ground.transform.position)
                             .CompareTo(Vector3.Distance(b.transform.position, BlockGameManager.instance.Ground.transform.position)));
        }
    }
    void SkillTarget()
    {
        SearchBlock();
        for (int i = 0; i < Mathf.Min(10, blocks.Count); i++)
        {
            GameObject enemy = blocks[i];
            if (enemy != null)
            {
                SkillDamage.Add(enemy.GetComponent<BlockManager>());
            }
        }
    }
    public void Break(GameObject bblock)
    {
        block = null;
        Destroy(bblock);
        Combo++;
        BlockGameManager.instance.Score += 100 + (100 * MyPet.pet.Score / 100);
        ItemManager.instance.gold += (1 * Combo) + MyPet.pet.Gold;
    }
    void ClearFun()
    {
        blocks.Clear();
        SkillDamage.Clear();
    }
    void DamageTextCreate(GameObject _hit, int _damage)
    {
        GameObject dmgtxt = Instantiate(dmgtext, _hit.transform.position, Quaternion.identity, canvas.transform);
        dmgtxt.GetComponent<Text>().text = _damage.ToString();
    }
}
