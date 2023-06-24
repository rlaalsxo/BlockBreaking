using UnityEngine;

public struct Block
{
    private int level, hp , damage;
    private float speed;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
}
public struct Weapon
{
    private int index, damage;
    private float length;
    private GameObject skill;
    public int Index
    {
        get { return index; }
        set { index = value; }
    }
    public float Length
    {
        get { return length; }
        set { length = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public GameObject Skill
    {
        get { return skill; }
        set { skill = value; }
    }
}
public struct Shoes
{
    private int index;
    private float power;
    private GameObject skill;
    public int Index
    {
        get { return index; }
        set { index = value; }
    }
    public float Power
    {
        get { return power; }
        set { power = value; }
    }
    public GameObject Skill
    {
        get { return skill; }
        set { skill = value; }
    }
}
[System.Serializable]
public struct Wave
{
    private float spawnTime;
    private int index;
    private int count;
    public float SpawnTime
    {
        get { return spawnTime; }
        set { spawnTime = value; }
    }
    public int Index
    {
        get { return index; }
        set { index = value; }
    }
    public int Count
    {
        get { return count; }
        set { count = value; }
    }
}
public struct Pet
{
    private int index;
    private int gold;
    private int hp;
    private int score;
    private int damage;
    public int Index
    {
        get { return index; }
        set { index = value; }
    }
    public int Gold
    {
        get { return gold; }
        set { gold = value; }
    }
    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
}
public class StructManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
