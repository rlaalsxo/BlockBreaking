using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    float time;
    private void Update()
    {
        time += Time.deltaTime;
        transform.position += transform.up * 0.4f;
        if(time >= 1f)
        {
            Destroy(this.gameObject);
        }
    }
}
