using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [SerializeField]
    GameObject HeartPos;
    [SerializeField]
    Image heart, JumpSG, AttackSG, GardG, BlockHp, IWave, BackGround, GameOver;
    [SerializeField]
    Slider ASkill, JSkill;
    [SerializeField]
    Text TGold, TScore, TWave, THp;
    [SerializeField]
    GameObject JumpSkill, AttackSkill, PetSkill;
    [SerializeField]
    GameObject[] PetSkills;
    [SerializeField]
    AudioClip[] DisAudio;
    [SerializeField]
    AudioSource Audio;
    int gold, score, wave, hp, currenthp, maxwave;
    CharacterManager player;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterManager>();
    }
    void Start()
    {
        for (int i = 0; i < player.hp; i++)
        {
            Instantiate(heart).transform.SetParent(HeartPos.transform, false);
        }
        GameObject petSkill = Instantiate(PetSkills[player.MyPet.pet.Index]);
        petSkill.transform.SetParent(PetSkill.transform, false);
        Audio.clip = DisAudio[player.MyPet.pet.Index];
        Audio.Play();
    }
    public void Jump()
    {
        player.Jump();
    }
    public void Attack()
    {
        player.Attack();
    }
    public void Defend()
    {
        player.Gard();
    }
    // Update is called once per frame
    void Update()
    {
        AttackManager();
        JumpManager();
        DefendManager();
        TextManager();
    }
    void JumpManager()
    {
        if(player.JumpCount < 10f)
        {
            JumpSG.fillAmount = player.JumpCount / 10f;
        }
        else if(player.JumpCount >= 10f)
        {
            JumpSG.fillAmount = 1f;
        }
        if (player.JumpCount >= 10f)
        {
            JumpSkill.SetActive(true);
        }
    }
    void AttackManager()
    {
        if (player.Combo < 10)
        {
            AttackSG.fillAmount = player.Combo / 10f;
        }
        else if (player.Combo >= 10)
        {
            AttackSG.fillAmount = 1f;
        }
        if (player.Combo >= 10)
        {
            AttackSkill.SetActive(true);
        }
    }
    void DefendManager()
    {
        if(player.skillcooltime < 2f)
        {
            GardG.fillAmount = (2f - player.skillcooltime) / 2f;
        }
        else if(player.skillcooltime >= 2f)
        {
            GardG.fillAmount = 0;
        }
    }
    void TextManager()
    {
        gold = ItemManager.instance.gold;
        score = BlockGameManager.instance.Score;
        wave = BlockGameManager.instance.waveindex + 1;
        maxwave = BlockGameManager.instance.waves.Length - 1;
        TGold.text = gold.ToString();
        TScore.text = score.ToString();
        TWave.text = wave.ToString();
        IWave.fillAmount = (float)wave / maxwave;
        if (player.block != null)
        {
            hp = player.block.block.HP;
            currenthp = player.block.currenthp;
            BlockHp.fillAmount = (float)currenthp / hp;
            THp.text = currenthp.ToString() + "/" + hp.ToString();
        }
    }
    public void JumpSk()
    {
        float a = JSkill.value;
        if (a > 0)
        {
            player.JumpSkill();
            JumpSkill.SetActive(false);
            player.JumpCount -= 10;
        }
    }
    public void AttackSk()
    {
        float a = ASkill.value;
        if (a > 0)
        {
            player.AttackSkill();
            AttackSkill.SetActive(false);
            player.Combo -= 10;
        }
    }
    public void HeartCount()
    {
        Audio.clip = DisAudio[5];
        Audio.Play();
        Destroy(HeartPos.transform.GetChild(HeartPos.transform.childCount - 1).gameObject);
        if(player.currenthp <= 0)
        {
            PauseGame();
            GameOver.gameObject.SetActive(true);
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        BackGround.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        BackGround.gameObject.SetActive(false);
    }
    public void GoHome()
    {
        ResumeGame();
        ItemManager.instance.StartLoad();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
