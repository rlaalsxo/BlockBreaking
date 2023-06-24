using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGameManager : MonoBehaviour
{
    public static BlockGameManager instance;
    [SerializeField]
    public Wave[] waves;
    public int waveindex = -1;
    public int Score, Wlevel;
    public Wave currentwave;
    public GameObject[] BlocksArray;
    public GameObject Ground;
    private void Awake()
    {
        waves = new Wave[12];
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator StartWaves()
    {
        while(waveindex < waves.Length - 1)
        {
            waveindex++;
            StartWave(waves[waveindex]);
            yield return new WaitForSeconds(20f);
        }
    }
    void StartWave(Wave wave)
    {
        currentwave = wave;
        currentwave.Count = 5;
        currentwave.Index = waveindex;
        currentwave.SpawnTime = 4f;
        StartCoroutine("CreateBlock");
    }
    IEnumerator CreateBlock()
    {
        int createCount = 0;
        while(createCount < currentwave.Count)
        {
            int index = Random.Range(currentwave.Index, currentwave.Index + 2);
            if(index < BlocksArray.Length)
            {
                GameObject obj = Instantiate(BlocksArray[index]);
                obj.transform.SetParent(transform);
                obj.transform.position = this.transform.position;
                createCount++;
            }
            else
            {
                GameObject obj = Instantiate(BlocksArray[BlocksArray.Length - 1]);
                obj.transform.SetParent(transform);
                obj.transform.position = this.transform.position;
                createCount++;
            }
            yield return new WaitForSeconds(currentwave.SpawnTime);
        }
    }
    void Start()
    {
        StartCoroutine(StartWaves());
    }
}
