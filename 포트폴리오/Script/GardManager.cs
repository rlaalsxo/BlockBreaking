using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardManager : MonoBehaviour
{
    CharacterManager player;
    float time = 0;
    [SerializeField]
    AudioClip GardAudio;
    [SerializeField]
    AudioSource GardAudioSource;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if(time > 0.5f)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Block")
        {
            other.GetComponent<Rigidbody>().velocity = other.transform.up * 6f;
            GardAudioSource.clip= GardAudio;
            GardAudioSource.Play();
            this.gameObject.SetActive(false);
        }
    }
}
